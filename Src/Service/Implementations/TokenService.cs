using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces;
using Repository.Interfaces.Unit;
using Logger.Interfaces;
using Common.Helpers;
using DTO.ViewModel.Token;
using DTO.Enums;
using Service.Models;
using DTO.Models;
using DTO.ViewModel.Account;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Service.Implementations
{
    internal class TokenService : ITokenService
    {

        private readonly IRepositoryUnit _repository;
        private readonly IMapper _mapper;
        private readonly IEventLogger _event;
        private readonly IEmailServices _emailServices;
        private static Random random = new Random();
        public TokenService(IRepositoryUnit repository, IMapper mapper, IEventLogger eventLogger, IEmailServices emailServices)
        {
            _repository = repository;
            _mapper = mapper;
            _event = eventLogger;
            _emailServices = emailServices;
        }
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
        public async Task<Tuple<bool, string>> IsTokenValidAsync(string authHeaderValue, List<AccountType> allows)
        {
            var result = false;
            var message = string.Empty;

            var tokenValues = authHeaderValue.Split(" ");

            if (tokenValues.Length != 2)
            {
                return Tuple.Create(result, message);
                //  return result;
            }

            var authToken = await _repository.AuthToken.GetByTokenAsync(tokenValues[1]);

            if (authToken == null)
            {
                return new Tuple<bool, string>(result, message);
                //return result;
            }

            if (authToken.IsLogout)
            {
                return new Tuple<bool, string>(result, message);
                //return result;
            }

            var tokenModel = ValidateToken(authToken.Token);

            if (tokenModel == null)
            {
                return new Tuple<bool, string>(result, message);
            }

            var date = DateTime.UtcNow;

            if (tokenModel.ExpiresAt < date)
            {
                return new Tuple<bool, string>(result, message);
            }

            if (allows != null && allows.Any())
            {
                if (allows.All(a => a != tokenModel.Type))
                {
                    return new Tuple<bool, string>(result, message);
                }
            }

            if (!authToken.AccountId.HasValue)
            {
                return new Tuple<bool, string>(result, message);
            }

            var account = await _repository.Account.GetByIdAsync(authToken.AccountId.Value);

            if (account == null)
            {
                return new Tuple<bool, string>(result, message);
            }

            if (account.AccountStatus != AccountStatusEnum.Active)
            {
                message = "Account Blocked";
                return new Tuple<bool, string>(result, message);
            }

            // token is valid
            result = true;
            return new Tuple<bool, string>(result, message);
        }
      /// <summary>
        /// Admin Can Access
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ServiceResult<object>> LogoutAsync(string token)
        {
            var authToken = await _repository.AuthToken.GetByTokenAsync(token);

            if (authToken == null)
            {
                return ServiceResults.Errors.InvalidJwtToken<object>(null);
            }

            if (authToken.IsLogout)
            {
                return ServiceResults.Errors.InvalidJwtToken<object>(null);
            }

            authToken.IsLogout = true;
            authToken.LogoutAt = DateTime.UtcNow;

            _repository.AuthToken.Update(authToken);
            await _repository.SaveAsync();

            return ServiceResults.SuccessfullyLogout<object>(true);
        }
        //Client Format  706479 is your Flyttom™ OTP.Do not share it with anyone
        private string OtpMsg(string phoneNumber, string OTP)
        {
            return " This Number of " + phoneNumber +" This "+ OTP + " is your Flyttom™ OTP.Do not share it with anyone";
        }
        //private string OtpMsg(string phoneNumber, string OTP)
        //{
        //    return OTP + " is your Flyttom™ OTP.Do not share it with anyone";
        //}
        public async Task<ServiceResult<string>> SignIn(AccountSignUpRequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.PhoneNumber))
                return ServiceResults.Errors.Required<string>("Phone Number", null);

            var isvalid = Extensions.IsValidPhone(model.PhoneNumber);
            if (isvalid == false)
                return ServiceResults.Errors.Invalid<string>("Phone Number", null);
            Account account = await _repository.Account.FindByCondition(x => x.PhoneNumber.Equals(model.PhoneNumber)).FirstOrDefaultAsync();
            string Name = "";
            //To Check If user wants to sign up
        
           

                return ServiceResults.AddedSuccessfully<string>("");
           

        }
    private int GenerateRandomNo()
        {
            int _min = 100000;
            int _max = 999999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }

}
