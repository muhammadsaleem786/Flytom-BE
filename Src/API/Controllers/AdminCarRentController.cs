using API.Attributes;
using API.Utils;
using DTO.Models;
using DTO.ViewModel;
using DTO.ViewModel.Account;
using DTO.ViewModel.Category;
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
    [Route("api/v1/AdminCarRent")]
    [ApiController]
    public class AdminCarRentController : ControllerBase
    {
        private readonly IServiceUnit _service;


        public AdminCarRentController(IServiceUnit service)
        {
            _service = service;
        }

        #region
        //Make Api
        [Route("MakeAddUpdate")]
        [HttpPost]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> MakeAddUpdate(MakeRequest model)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Makes.AddUpdate(model, tokenModel.Id);

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

        [Route("MakeDelete")]
        [HttpDelete]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> MakeDelete(long Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Makes.Delete(Id, tokenModel.Id);

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
        [Route("GetMakesList")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<MakeResponseList>>>> GetMakesList(int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                decimal AccountId = 0;
                var result = await _service.Makes.GetMakesList(AccountId, CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText, IgnorePaging = false);

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
        [Route("GetMakeById")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<Makes>>> GetMakeById(int Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);

                var result = await _service.Makes.GetById(Id);

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
        #region
        //Category Api
        [Route("CategoryAddUpdate")]
        [HttpPost]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> CategoryAddUpdate(CategoryRequest model)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Category.AddUpdate(model, tokenModel.Id);

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

        [Route("CategoryDelete")]
        [HttpDelete]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> CategoryDelete(long Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Category.Delete(Id, tokenModel.Id);

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
        [Route("GetCategoryList")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<CategoryResponse>>>> GetCategoryList(int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                decimal AccountId = 0;
                var result = await _service.Category.GetCategoryList(AccountId, CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText, IgnorePaging = false);

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
        [Route("GetCategoryById")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<Category>>> GetCategoryById(int Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);

                var result = await _service.Category.GetById(Id);

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
        #region
        //Model Api
        [Route("ModelAddUpdate")]
        [HttpPost]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> ModelAddUpdate(ModelRequest model)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.VehicleModels.AddUpdate(model, tokenModel.Id);

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
        [Route("ModelDelete")]
        [HttpDelete]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> ModelDelete(long Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.VehicleModels.Delete(Id, tokenModel.Id);

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
        [Route("GetModelList")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<ModelResponseList>>>> GetModelList(int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                decimal AccountId = 0;

                var result = await _service.VehicleModels.GetModelList(AccountId, CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText, IgnorePaging = false);

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
        [Route("GetModelById")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<VehicleModels>>> GetModelById(int Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);

                var result = await _service.VehicleModels.GetById(Id);

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
        //Vehicle Api
        #region
        [Route("VehicleAddUpdate")]
        [HttpPost]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> VehicleAddUpdate(VehicleRequest model)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Vehicle.AddUpdate(model, tokenModel.Id);

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

        [Route("VehicleDelete")]
        [HttpDelete]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> VehicleDelete(long Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Vehicle.Delete(Id, tokenModel.Id);

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
        [Route("GetVehicleList")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<VehicleResponseModel>>>> GetVehicleList(int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                decimal AccountId = 0;
                var result = await _service.Vehicle.GetVehicleList(AccountId, CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText, IgnorePaging = false);

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
        [Route("GetVehicleById")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<Vehicle>>> GetVehicleById(int Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);

                var result = await _service.Vehicle.GetById(Id);

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
                var AllData = dataAccessManager.GetDataSet("SP_LoadDropdown", ht);

                var makeList = AllData.Tables[0].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var ModelList = AllData.Tables[1].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name"),
                    MakeId= row.Field<long>("MakeId"),
                }).ToList();
                var FuelTypeList = AllData.Tables[2].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var DriveWheelTypeList = AllData.Tables[3].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var SteeringTypeList = AllData.Tables[4].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var CategoryList = AllData.Tables[5].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name"),
                    CarType = row.Field<string>("CarType")
                }).ToList();

                var LicenceTypeList = AllData.Tables[6].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();

                var SequreFeetList = AllData.Tables[7].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var SeatList = AllData.Tables[8].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();

                var PartList = AllData.Tables[9].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();

                objResponse.ResultSet = new
                {
                    makeList = makeList,
                    ModelList = ModelList,
                    FuelTypeList = FuelTypeList,
                    DriveWheelTypeList = DriveWheelTypeList,
                    SteeringTypeList = SteeringTypeList,
                    PCategoryList = CategoryList.Where(a=>a.CarType=="P").ToList(),
                    VCategoryList = CategoryList.Where(a => a.CarType == "V").ToList(),
                    LicenceTypeList = LicenceTypeList,
                    SeatList = SeatList,
                    SequreFeetList = SequreFeetList,
                    PartList = PartList,
                };
            }
            catch (Exception ex)
            {
                objResponse.IsSuccess = false;
                objResponse.ErrorMessage = ex.Message;
            }
            return objResponse;
        }
        [Route("LoadDropdown")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<MakeResponseList>>>> LoadDropdown()
        {
            try
            {

                var result = await _service.Makes.GetMakesList();

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
        [HttpGet]
        [Route("Load")]
        public async Task<ResponseInfo> Load()
        {

            var objResponse = new ResponseInfo();
            try
            {
                var makeList = await _service.Makes.GetMakesList();
                var ModelList = await _service.VehicleModels.GetModelList();
                objResponse.ResultSet = new
                {
                    makeList = makeList,
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

        [Route("LoadModelByMakeId")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<ModelResponseList>>>> LoadModelByMakeId(int Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);

                var result = await _service.VehicleModels.LoadModelByMakeId(Id);

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
