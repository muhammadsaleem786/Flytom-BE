using API.Attributes;
using API.Utils;
using DTO.Enums;
using DTO.ViewModel.Account;
using DTO.ViewModel.Token;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Unit;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IServiceUnit _service;

        public AccountController(IServiceUnit service)
        {
            _service = service;
        }
        [Route("signup")]
        [HttpPost]
        public async Task<ActionResult<ServiceResult<string>>> SignUpAsync([FromForm] AccountSignUpRequestModel model)
        {
            try
            {
                var result = await _service.Account.SignUp(model);

                if (result.IsSuccess)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ServiceResults.Errors.UnhandledError<object>(ex.Message.ToString(), null));
            }
        }
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<ServiceResult<AuthModel>>> LoginAsync(Login model)
        {
            try
            {
                var result = await _service.Account.LoginAsync(model);

                //if (result.IsSuccess)
                    return Ok(result);
                //else
                //    return BadRequest(ServiceResults.Errors.UnhandledError<object>(result.Message.ToString(), result));
           
            }
            catch (Exception ex)
            {
                return BadRequest(ServiceResults.Errors.UnhandledError<object>(ex.Message.ToString(), null));
            }
        }
        [Route("ForgetPassword")]
        [HttpPost]
        public async Task<ActionResult<ServiceResult<string>>> ForgetPassword(ForgotPasswordRequestModel model)
        {
            try
            {
                var result = await _service.Account.SendForgotEmail(model);

                if (result.IsSuccess)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ServiceResults.Errors.UnhandledError<object>(ex.Message.ToString(), null));
            }
        }
        [Route("ChangePassword")]
        [HttpPost]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> ChangePassword(ChangePasswordRequestModel model)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Account.ChangePassword(tokenModel.Id, model);

                if (result.IsSuccess)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ServiceResults.Errors.UnhandledError<object>(ex.Message.ToString(), null));
            }
        }
        [HttpPost]
        [Route("UpdateAccount")]
        public async Task<ActionResult<ServiceResult<AccountViewModel>>> UpdateAccountAsync([FromForm] UpdateAccountRequestModel model)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Account.UpdateAccountAsync(tokenModel.Id, model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ServiceResults.Errors.UnhandledError<object>(ex.Message.ToString(), null));
            }
        }

        [HttpGet]
        [Route("GetUserAccount")]
        public async Task<ActionResult<ServiceResult<GetUserAccountResponseModel>>> GetUserAccount()
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Account.GetUserAccount(tokenModel.Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ServiceResults.Errors.UnhandledError<object>(ex.Message.ToString(), null));
            }
        }
        [HttpGet]
        [Route("GetAllAccounts")]
        public async Task<ActionResult<ServiceListResult<List<AccountViewModel>>>> GetAllAccounts([FromQuery] PaginationModel paginationModel)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                ServiceListResult<List<AccountViewModel>> result = await _service.Account.GetAllAccounts(paginationModel);
                result.CurrentPage = paginationModel.CurrentPage.Value;
                result.PageSize = paginationModel.PageSize.Value;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ServiceResults.Errors.UnhandledError<object>(ex.Message.ToString(), null));
            }
        }



    }

}
