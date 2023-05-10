using API.Attributes;
using API.Utils;
using DTO.Models;
using DTO.ViewModel;
using DTO.ViewModel.Account;
using DTO.ViewModel.Category;
using DTO.ViewModel.ContentManagment;
using DTO.ViewModel.Make;
using DTO.ViewModel.Model;
using DTO.ViewModel.Token;
using DTO.ViewModel.Vehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Unit;
using Service.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/Content")]
    [ApiController]
    public class ContentManagmentController : ControllerBase
    {
        private readonly IServiceUnit _service;
        public ContentManagmentController(IServiceUnit service)
        {
            _service = service;
        }
        #region
        [Route("AddUpdate")]
        [HttpPost]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> AddUpdate(ContentManagmentRequest model)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.ContentManagment.AddUpdate(model, tokenModel.Id);

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
        [HttpPost("uploadImage")]
        [HttpPost]
        public async Task<IActionResult> UploadImage()
        {

            try
            {
                var files = new List<IFormFile>();

                foreach (var file in Request.Form.Files)
                {
                    if (file.Length > 0)
                    {
                        files.Add(file);
                    }
                }
                var result = await _service.Vehicle.UploadImage(files);

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
                var result = await _service.ContentManagment.Delete(Id, tokenModel.Id);

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
        [Route("GetList")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<ContentListManagmentResponse>>>> GetList(int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                decimal AccountId = 0;
                var result = await _service.ContentManagment.GetList(AccountId, CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText, IgnorePaging = false);

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
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<ContentManagmentResponse>>> GetById(int Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);

                var result = await _service.ContentManagment.GetById(Id);

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
        #endregion

        [HttpGet]
        [Route("GetSysDropdown")]
        public ResponseInfo GetSysDropdown()
        {
            var objResponse = new ResponseInfo();
            try
            {
                //var token = RequestUtil.GetToken(HttpContext);
                //var tokenModel = _service.Token.ValidateToken(token);
                DataAccessManager dataAccessManager = new DataAccessManager();
                var ht = new Hashtable();
                var AllData = dataAccessManager.GetDataSet("SP_MovingLoadDropdown", ht);

                var ContentList = AllData.Tables[6].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                

                objResponse.ResultSet = new
                {
                    ContentList = ContentList,
                    
                };
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
            }
            return objResponse;
        }
        [HttpGet]
        [Route("Load")]
        public async Task<ResponseInfo> Load()
        {

            var objResponse = new ResponseInfo();
            try
            {
                 var ModelList = await _service.VehicleModels.GetModelList();
                objResponse.ResultSet = new
                {
                    ModelList = ModelList,
                };
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
            }
            return objResponse;
        }


    }
}
