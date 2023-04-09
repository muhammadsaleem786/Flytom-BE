using API.Attributes;
using API.Utils;
using DTO.Models;
using DTO.ViewModel;
using DTO.ViewModel.Account;
using DTO.ViewModel.Token;
using DTO.ViewModel.Vehicle;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Unit;
using Service.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/v1/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IServiceUnit _service;
        public HomeController(IServiceUnit service)
        {
            _service = service;
        }
        [Route("GetWebVehicleList")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<VehicleResponseModel>>>> GetWebVehicleList(int CurrentPageNo, int RecordPerPage, string SortOrder, string SearchText,string Type)
        {
            try
            {
                decimal AccountId = 0;
                var result = await _service.Vehicle.GetWebVehicleList(AccountId, CurrentPageNo, RecordPerPage   , SortOrder, SearchText, Type);

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
        public async Task<ActionResult<ServiceResult<VehicleWebResponse>>> GetVehicleById(string Id,string Type)
        {
            try
            {

                var result = await _service.Vehicle.GetByIdWebSite(Convert.ToInt32(Id), Type);

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
        [Route("GetDropdown")]
        public ResponseInfo GetDropdown()
        {
            var objResponse = new ResponseInfo();
            try
            {
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
                    MakeId = row.Field<long>("MakeId"),
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
                    PCategoryList = CategoryList.Where(a => a.CarType == "P").ToList(),
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
    }
}
