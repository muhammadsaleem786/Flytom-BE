using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Interfaces;
using Repository.Interfaces.Unit;
using Service.Interfaces;
using Service.Implementations;
using Service.Interfaces.Unit;

namespace Service.Implementations.Unit
{
    internal class ServiceUnit : IServiceUnit
    {
        private readonly IRepositoryUnit _repository;
        private readonly IMapper _mapper;
        private readonly IEventLogger _eventLogger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFileManagementService _fileManagement;

        private IEmailServices _email;
        private ITokenService _token;
        private IAccountService _account;

        private IMakeService _Make;
        private IVehicleModelService _vehicleModel;
        private IVehicleService _vehicle;
        private ICategoryService _Category;


        private IDropDownMfService _DropDownMf;
        private IDropDownValueService _DropDownValue;
        private IOfferService _Offer;


        public ServiceUnit(IRepositoryUnit repository, IFileManagementService fileManagementService, IMapper mapper, IEventLogger eventLogger, IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _mapper = mapper;
            _eventLogger = eventLogger;
            _hostingEnvironment = hostingEnvironment;
            _fileManagement = fileManagementService;
        }
        public IDropDownMfService DropDownMf =>
           _DropDownMf ??= new DropDownMfServices(_repository, Email, _eventLogger, _mapper, _fileManagement);
        public IDropDownValueService DropDownValue =>
           _DropDownValue ??= new DropDownValueServices(_repository, Email, _eventLogger, _mapper, _fileManagement);
        public IOfferService Offer =>
           _Offer ??= new OfferServices(_repository, Email, _eventLogger, _mapper, _fileManagement);


        public IMakeService Makes =>
           _Make ??= new MakeServices(_repository, Email, _eventLogger, _mapper, _fileManagement);

        public ICategoryService Category =>
         _Category ??= new CategoryServices(_repository, Email, _eventLogger, _mapper, _fileManagement);

        public IVehicleModelService VehicleModels =>
                   _vehicleModel ??= new VehicleModelServices(_repository, Email, _eventLogger, _mapper, _fileManagement);
        public IVehicleService Vehicle =>
                   _vehicle ??= new  VehicleServices(_repository, Email, _eventLogger, _mapper, _fileManagement);



        public IEmailServices Email =>
            _email ??= new EmailServices(_hostingEnvironment, _eventLogger);

      

        public IAccountService Account =>
            _account ??= new AccountService(_repository, Email, _eventLogger, _mapper, _fileManagement);

        public ITokenService Token =>
      _token ??= new TokenService(_repository, _mapper, _eventLogger, Email);
     
    }
}
