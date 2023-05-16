using API.Attributes;
using API.Utils;
using DTO.Models;
using DTO.ViewModel;
using DTO.ViewModel.Account;
using DTO.ViewModel.Contact;
using DTO.ViewModel.Make;
using DTO.ViewModel.Offer;
using DTO.ViewModel.Token;
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
    [Route("api/v1/moving")]
    [ApiController]
    public class MovingController : ControllerBase
    {
        private readonly IServiceUnit _service;


        public MovingController(IServiceUnit service)
        {
            _service = service;
        }
        #region
        //Contact Api
        [Route("ContactAddUpdate")]
        [HttpPost]
        public async Task<ActionResult<ServiceResult<string>>> ContactAddUpdate(ContactRequest model)
        {
            try
            {
                //var token = RequestUtil.GetToken(HttpContext);
                //var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Contact.AddUpdate(model, 0);

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

        [Route("ContactDelete")]
        [HttpDelete]
        [CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> ContactDelete(long Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                var result = await _service.Contact.Delete(Id, tokenModel.Id);

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
        [Route("GetContactList")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<MakeResponseList>>>> GetContactList(int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);
                decimal AccountId = 0;
                var result = await _service.Contact.GetContactList(AccountId, CurrentPageNo, RecordPerPage, VisibleColumnInfo, SortName, SortOrder, SearchText, IgnorePaging = false);

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
        [Route("GetContactById")]
        [HttpGet]
        public async Task<ActionResult<ServiceResult<Contact>>> GetContactById(int Id)
        {
            try
            {
                var token = RequestUtil.GetToken(HttpContext);
                var tokenModel = _service.Token.ValidateToken(token);

                var result = await _service.Contact.GetById(Id);

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
        [Route("AddUpdate")]
        [HttpPost]
        //[CheckJwtToken]
        public async Task<ActionResult<ServiceResult<string>>> AddUpdate(OfferRequest model)
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
        public async Task<ActionResult<ServiceResult<MovingOffer>>> GetOfferById(int Id)
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
        [HttpGet]
        [Route("GetDropdown")]
        public ResponseInfo GetDropdown()
        {
            var objResponse = new ResponseInfo();
            try
            {
                DataAccessManager dataAccessManager = new DataAccessManager();
                var ht = new Hashtable();
                var AllData = dataAccessManager.GetDataSet("SP_MovingLoadDropdown", ht);

                var FlexibleMovingLoadList = AllData.Tables[0].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var ApproximatelyList = AllData.Tables[1].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var peopleList = AllData.Tables[2].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var TotalRoomList = AllData.Tables[3].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var HouseTypeList = AllData.Tables[4].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var FloorsList = AllData.Tables[5].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();

                var floorList = AllData.Tables[7].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var EmployeeList = AllData.Tables[8].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var FloorsTypeList = AllData.Tables[9].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                var ContactList = AllData.Tables[10].AsEnumerable().Select(row => new
                {
                    ID = row.Field<long>("ID"),
                    Name = row.Field<string>("Name")
                }).ToList();
                objResponse.ResultSet = new
                {
                    FlexibleMovingLoadList = FlexibleMovingLoadList,
                    ApproximatelyList = ApproximatelyList,
                    peopleList = peopleList,
                    TotalRoomList = TotalRoomList,
                    HouseTypeList = HouseTypeList,
                    FloorsList = FloorsList,
                    floorList= floorList,
                    EmployeeList= EmployeeList,
                    FloorsTypeList= FloorsTypeList,
                    ContactList= ContactList,
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
