using API.Attributes;
using API.Utils;
using DTO.Models;
using DTO.ViewModel.Account;
using DTO.ViewModel.Make;
using DTO.ViewModel.Offer;
using DTO.ViewModel.Token;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Unit;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/moving")]
    [ApiController]
    public class MovingController : ControllerBase
    {
        private readonly IServiceUnit _service;


        public MovingController(IServiceUnit service)
        {
            _service = service;
        }
        [Route("AddUpdate")]
        [HttpPost]
        //[CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> AddUpdate([FromForm] OfferRequest model)
        {
            try
            {
                //var token = RequestUtil.GetToken(HttpContext);
                //var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Offer.AddUpdate(model, 0);

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

        [Route("Delete")]
        [HttpDelete]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> Delete(long Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Offer.Delete(Id, tokenModel.Id);

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
        [Route("GetOfferById")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<Offer>>> GetOfferById(int Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);

                var result = await _service.Offer.GetById(Id);

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
