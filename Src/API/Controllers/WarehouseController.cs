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
    [Route("api/v1/warehouse")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IServiceUnit _service;


        public WarehouseController(IServiceUnit service)
        {
            _service = service;
        }


    }
}
