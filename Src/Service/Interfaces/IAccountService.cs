using DTO.ViewModel.Account;
using DTO.ViewModel.Token;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResult<string>> SignUp(AccountSignUpRequestModel model);
        Task<ServiceResult<AuthModel>> LoginAsync(Login model);
        Task<ServiceResult<string>> ChangePassword(long id, ChangePasswordRequestModel model);
        Task<ServiceResult<string>> SendForgotEmail(ForgotPasswordRequestModel model);
        Task<ServiceResult<AccountViewModel>> UpdateAccountAsync(long accountId, UpdateAccountRequestModel model);
        Task<ServiceResult<GetUserAccountResponseModel>> GetUserAccount(long accountId);
        Task<ServiceListResult<List<AccountViewModel>>> GetAllAccounts(PaginationModel model);
    }
}
