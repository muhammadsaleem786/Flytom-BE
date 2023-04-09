using DTO.Enums;
using DTO.ViewModel.Account;
using DTO.ViewModel.Token;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITokenService
    {

       JwtTokenModel ValidateToken(string token);
        Task<Tuple<bool, string>> IsTokenValidAsync(string authHeaderValue, List<AccountType> allows);

         Task<ServiceResult<string>> SignIn(AccountSignUpRequestModel model);
        //Task<ServiceResult<string>> SignIn(AccountSignUpRequestModel model);
        /// <summary>
        /// Admin can Access
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ServiceResult<object>> LogoutAsync(string token);
 
        //Task<ServiceResult<string>> SignUp(AccountSignUpRequestModel model);
    }
}
