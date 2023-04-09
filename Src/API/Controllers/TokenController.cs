using API.Attributes;
using API.Utils;
using DTO.ViewModel.Account;
using DTO.ViewModel.Token;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Unit;
using Service.Models;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceUnit _service;


        public TokenController(IServiceUnit service)
        {
            _service = service;
        }

        [Route("logout")]
        [HttpGet]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<bool>>> LogoutAsync()
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);

                var result = await _service.Token.LogoutAsync(token);

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

      


    }
}
