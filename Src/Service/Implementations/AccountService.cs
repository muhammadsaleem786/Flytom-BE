using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Service.Interfaces;
using Logger.Interfaces;
using Repository.Interfaces.Unit;
using Service.Models;
using DTO.ViewModel.Account;
using Microsoft.EntityFrameworkCore;
using DTO.Models;
using DTO.Enums;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using DTO.ViewModel.Token;
using System.Security.Claims;
using Common.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Diagnostics;

namespace Service.Implementations
{
    internal class AccountService : IAccountService
    {
        private readonly IRepositoryUnit _repository;
        private readonly IEmailServices emailServices;
        private readonly IEventLogger eventLogger;
        private readonly IFileManagementService fileManagementService;
        private readonly IMapper mapper;
        private static ClaimsPrincipal GetPrincipal(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            if (jwtToken == null)
                return null;
            byte[] key = Encoding.ASCII.GetBytes(AppSettingHelper.GetJwtTokenSecret());
            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
            return tokenHandler.ValidateToken(token,
                parameters, out _);
        }
        private string GenerateToken(long id, int type)
        {
            byte[] key = Encoding.ASCII.GetBytes(AppSettingHelper.GetJwtTokenSecret());

            var securityKey = new SymmetricSecurityKey(key);
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(TokenClaimKeys.Value, CryptoHelper.SymmetricEncryptString(AppSettingHelper.GetJwtValueSecret(), id.ToString())),
                    new Claim(TokenClaimKeys.Type, CryptoHelper.SymmetricEncryptString(AppSettingHelper.GetJwtValueSecret(), type.ToString())),
                }),

                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
        public AccountService(IRepositoryUnit repository, IEmailServices emailServices, IEventLogger eventLogger, IMapper mapper, IFileManagementService fileManagementService)
        {
            _repository = repository;
            this.emailServices = emailServices;
            this.eventLogger = eventLogger;
            this.mapper = mapper;
            this.fileManagementService = fileManagementService;
        }


        public JwtTokenModel ValidateToken(string token)
        {
            try
            {
                ClaimsPrincipal principal = GetPrincipal(token);
                if (principal == null)
                    return null;
                ClaimsIdentity identity = (ClaimsIdentity)principal.Identity;

                // Token values
                var id = long.Parse(CryptoHelper.SymmetricDecryptString(AppSettingHelper.GetJwtValueSecret(), identity.FindFirst(TokenClaimKeys.Value).Value));

                var issuedAt = long.Parse(identity.FindFirst(TokenClaimKeys.IssuedAt).Value);

                var expiresAt = long.Parse(identity.FindFirst(TokenClaimKeys.ExpiresAt).Value);

                var notValidBefore = long.Parse(identity.FindFirst(TokenClaimKeys.NotValidBefore).Value);

                var type = int.Parse(CryptoHelper.SymmetricDecryptString(AppSettingHelper.GetJwtValueSecret(),
                        identity.FindFirst(TokenClaimKeys.Type).Value));

                return new JwtTokenModel(id, issuedAt, expiresAt, notValidBefore, (AccountType)type);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<ServiceResult<string>> SignUp(AccountSignUpRequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email))
                return ServiceResults.Errors.Required<string>("Email", null);

            if (string.IsNullOrWhiteSpace(model.Password))
                return ServiceResults.Errors.Required<string>("Password", null);

            if (!DataValidationHelper.IsValidEmail(model.Email))
                return ServiceResults.Errors.Invalid<string>("Email", null);

            if (_repository.Account.AnyAccountByEmail(model.Email))
                return ServiceResults.Errors.HasEmail<string>(model.Email, null);
            var profileimage = "";
            if (model.ProfileImage != null)
            {
                var result = await fileManagementService.UploadProfileImageFile(model.ProfileImage, "", new string[] { "image/jpeg", "image/png", "image/gif" }, 20971520);
                if (result.isSuccess)
                {
                    profileimage = result.response;

                }
            }

            Account account = new Account()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Password = TrippleDES.Encrypt(model.Password, AppSettingHelper.GetMasterKey),
                Address = model.Address,
                AccountType = AccountType.User,
                ProfileImage = profileimage,
                AccountStatus = AccountStatusEnum.Active,
                IsEmailVerified = true,
                IsVerifiedAccount = true,
                DateOfBirth = model.DateOfBirth,
                GanderType = model.GanderType,
            };
            _repository.Account.Create(account);
            await _repository.SaveAsync();
            return ServiceResults.AddedSuccessfully<string>("Account Registered");
        }
        public async Task<ServiceResult<AuthModel>> LoginAsync(Login model)
        {
            try
            {
                long id;
                string token = string.Empty;
                DateTime? extdate = null;
                model.Pwd = TrippleDES.Encrypt(model.Pwd, AppSettingHelper.GetMasterKey);

                Account account = _repository.Account.GetAccountByEmail(model.Email, model.Pwd);
                if (account != null)
                {
                    if (account.IsEmailVerified == false)
                    {
                        return ServiceResults.Errors.InvalidUsernameOrPassword<AuthModel>(null);
                    }
                    else if (account == null)
                    {
                        return ServiceResults.Errors.InvalidUsernameOrPassword<AuthModel>(null);
                    }
                }
                if (account == null)
                {
                    account = _repository.Account.GetAccountByEmail(model.Email);
                    if (account == null)
                        return ServiceResults.Errors.InvalidUsernameOrPassword<AuthModel>(null);
                    var oldpassword = TrippleDES.Encrypt(account.Password, AppSettingHelper.GetMasterKey);

                    if (oldpassword != model.Pwd)
                        return ServiceResults.Errors.InvalidUsernameOrPassword<AuthModel>(null);
                }
                id = account.Id;
                var TokenEntry = _repository.AuthToken.GetByAccountId(id);
                if (TokenEntry != null)
                {
                    TokenEntry.CreatedAt = DateTime.UtcNow;
                    TokenEntry.IsLogout = false;
                    TokenEntry.AccountId = account.Id;
                    token = GenerateToken(id, (int)account.AccountType);
                    JwtTokenModel jwt = ValidateToken(token);
                    TokenEntry.AccountType = account.AccountType;
                    TokenEntry.IssuedAt = jwt.IssuedAt;
                    extdate = jwt.ExpiresAt;
                    TokenEntry.ExpiresAt = jwt.ExpiresAt;
                    TokenEntry.NotValidBefore = jwt.NotValidBefore;
                    TokenEntry.Token = token;
                    _repository.AuthToken.Update(TokenEntry);
                }
                else
                {
                    AuthToken authToken = new AuthToken()
                    {
                        CreatedAt = DateTime.UtcNow,
                        IsLogout = false
                    };
                    authToken.AccountId = account.Id;
                    token = GenerateToken(id, (int)account.AccountType);
                    JwtTokenModel jwt = ValidateToken(token);
                    authToken.AccountType = account.AccountType;
                    authToken.IssuedAt = jwt.IssuedAt;
                    extdate = jwt.ExpiresAt;
                    authToken.ExpiresAt = jwt.ExpiresAt;
                    authToken.NotValidBefore = jwt.NotValidBefore;
                    authToken.Token = token;
                    _repository.AuthToken.Create(authToken);
                }
                var resultname = new AccountViewModel();
                await _repository.SaveAsync();
                _repository.Account.Update(account);
                await _repository.SaveAsync();

                AuthModel resultData = new AuthModel()
                {
                    Token = token,
                    ValidTo= extdate,
                    UserInfo = null
                };
                return ServiceResults.SuccessfullyLogin<AuthModel>(resultData);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
        public async Task<ServiceResult<string>> ChangePassword(long id, ChangePasswordRequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.OldPassword))
                return ServiceResults.Errors.Required<string>("Old Password", null);
            var account = await _repository.Account.GetByIdAsync(id);
            if (account == null)
                return ServiceResults.Errors.NotFound<string>("Account", null);
            var oldpassword = TrippleDES.Encrypt(model.OldPassword, AppSettingHelper.GetMasterKey);
            if (account.Password != oldpassword)
                return ServiceResults.Errors.Invalid<string>("Password", null);

            account.Password = TrippleDES.Encrypt(model.NewPassword, AppSettingHelper.GetMasterKey);
            _repository.Account.Update(account);
            await _repository.SaveAsync();
            _ = eventLogger.LogEvent(account.Id.ToString(), "User", "Password changed", new { });
            return ServiceResults.UpdatedSuccessfully<string>("Password changed");
        }
        public async Task<ServiceResult<string>> SendForgotEmail(ForgotPasswordRequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Email))
                return ServiceResults.Errors.Required<string>("Email", null);

            if (!DataValidationHelper.IsValidEmail(model.Email))
                return ServiceResults.Errors.Invalid<string>("Email", null);
            var account = _repository.Account.GetAccountByEmail(model.Email);
            if (account == null || account.IsDeleted == true)
                return ServiceResults.Errors.NotFound<string>("User with this email", null);


            await _repository.SaveAsync();
            var code = Guid.NewGuid().ToString().Replace("-", "");
            _ = emailServices.SendForgotEmailAsync(account.Email, account.Email, Token: code);
            return ServiceResults.AddedSuccessfully<string>("Please check your email for change password link");
        }
        public async Task<ServiceResult<AccountViewModel>> UpdateAccountAsync(long accountId, UpdateAccountRequestModel model)
        {
            try
            {
                if (model == null)
                {
                    await eventLogger.LogEvent("Update", "User", "updateAccountAsync", new { Error = "Account object sent from client is null" });
                    return ServiceResults.Errors.NotFound<AccountViewModel>("Account", null);

                }

                var account = await _repository.Account.GetByIdAsync(accountId);
                if (account == null)
                {
                    await eventLogger.LogEvent("Id", "User", "updateAccountAsync", new { Error = "Account Not Found" });
                    return ServiceResults.Errors.NotFound<AccountViewModel>("Account", null);
                }

                account.FirstName = model.FirstName;
                account.LastName = model.LastName;
                account.PhoneNumber = model.PhoneNumber;
                account.Email = model.Email;
                account.Address = model.Address;
                if (model.Password != null && model.Password != "")
                    account.Password = TrippleDES.Encrypt(model.Password, AppSettingHelper.GetMasterKey);
                if (model.ProfileImage != null)
                {
                    var result = await fileManagementService.UploadProfileImageFile(model.ProfileImage, "", new string[] { "image/jpeg", "image/png", "image/gif" }, 20971520);
                    if (result.isSuccess)
                    {
                        account.ProfileImage = result.response;

                    }
                }

                _repository.Account.Update(account);
                await _repository.SaveAsync();

                return ServiceResults.TUpdatedSuccessfully<AccountViewModel>("Profile", mapper.Map<AccountViewModel>(account));
            }
            catch (Exception ex)
            {
                await eventLogger.LogEvent("Exception", "User", "updateAccountAsync", new { ex.Message });
                return ServiceResults.Errors.UnhandledError<AccountViewModel>(ex.Message, null);
            }

        }
        public async Task<ServiceResult<GetUserAccountResponseModel>> GetUserAccount(long accountId)
        {
            try
            {
                Account user = null;
                var account = await _repository.Account.GetByIdAsync(accountId);

                if (account == null)
                {
                    await eventLogger.LogEvent("Address", "User", "GetUserAccount", new { Error = "Account Not Found" });
                    return ServiceResults.Errors.NotFound<GetUserAccountResponseModel>("Account", null);
                }


                var accountModel = mapper.Map<AccountViewModel>(account);



                GetUserAccountResponseModel model = new GetUserAccountResponseModel()
                {
                    AccountViewModel = accountModel,
                };

                return ServiceResults.GetSuccessfully(model);
            }
            catch (Exception ex)
            {

                await eventLogger.LogEvent("Exception", "User", "GetUserAccount", new { ex.Message });
                return ServiceResults.Errors.UnhandledError<GetUserAccountResponseModel>(ex.Message, null);
            }
        }
        public async Task<ServiceListResult<List<AccountViewModel>>> GetAllAccounts(PaginationModel model)
        {
            try
            {
                var query = _repository.Account.FindAll();

                if (!string.IsNullOrEmpty(model.Search))
                {
                    var date = new DateTime();
                    var sdate = DateTime.TryParse(model.Search, out date);
                    int totalCases = -1;
                    var isNumber = Int32.TryParse(model.Search, out totalCases);
                    query = query.Where(
                        x => x.FirstName.ToLower().Contains(model.Search.ToLower())
                      );
                }

                query = query.OrderByDescending(w => w.CreatedAt);


                switch (model.SortIndex)
                {
                    case 0:
                        query = model.SortBy == "desc" ? query.OrderByDescending(x => x.FirstName) : query.OrderBy(x => x.FirstName);
                        break;
                    case 1:
                        query = model.SortBy == "desc" ? query.OrderByDescending(x => x.Email) : query.OrderBy(x => x.Email);
                        break;
                    case 2:
                        query = model.SortBy == "desc" ? query.OrderByDescending(x => x.AccountStatus) : query.OrderBy(x => x.AccountStatus);
                        break;
                    case 3:
                        query = model.SortBy == "desc" ? query.OrderByDescending(x => x.Address) : query.OrderBy(x => x.Address);
                        break;

                }


                var total = await query.CountAsync();
                query = query.Page(model.CurrentPage.Value, model.PageSize.Value);
                var data = await query.ToListAsync();

                var responses = mapper.Map<List<AccountViewModel>>(data);

                await eventLogger.LogEvent("", "Admin", "Getting All User", new { Success = true, ItemCount = total });
                return ServiceResults.GetListSuccessfully<List<AccountViewModel>>(responses, total);
            }
            catch (Exception ex)
            {

                await eventLogger.LogEvent("Exception", "User", "GetAllAccounts", new { ex.Message });
                return ServiceResults.Errors.UnhandledListError<List<AccountViewModel>>(ex.Message, null);
            }

        }
       


    }
}
