using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Service.Interfaces;
using Logger.Interfaces;
using Repository.Interfaces.Unit;
using Service.Models;
using DTO.ViewModel.Account;
using Microsoft.EntityFrameworkCore;
using DTO.Models;
using DTO.Enums;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using DTO.ViewModel.Token;
using System.Security.Claims;
using Common.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Diagnostics;
using DTO.ViewModel.Make;

namespace Service.Implementations
{
    internal class DropDownMfServices : IDropDownMfService
    {
        private readonly IRepositoryUnit _repository;
        private readonly IEmailServices emailServices;
        private readonly IEventLogger eventLogger;
        private readonly IFileManagementService fileManagementService;
        private readonly IMapper mapper;
        public DropDownMfServices(IRepositoryUnit repository, IEmailServices emailServices, IEventLogger eventLogger, IMapper mapper, IFileManagementService fileManagementService)
        {
            _repository = repository;
            this.emailServices = emailServices;
            this.eventLogger = eventLogger;
            this.mapper = mapper;
            this.fileManagementService = fileManagementService;
        }
       
    }
}
