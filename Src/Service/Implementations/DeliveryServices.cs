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
using DTO.ViewModel.Offer;
using System.Collections;
using DTO.ViewModel.Delivery;

namespace Service.Implementations
{
    internal class DeliveryServices : IDeliveryService
    {
        private readonly IRepositoryUnit _repository;
        private readonly IEmailServices emailServices;
        private readonly IEventLogger eventLogger;
        private readonly IFileManagementService fileManagementService;
        private readonly IMapper mapper;
        public DeliveryServices(IRepositoryUnit repository, IEmailServices emailServices, IEventLogger eventLogger, IMapper mapper, IFileManagementService fileManagementService)
        {
            _repository = repository;
            this.emailServices = emailServices;
            this.eventLogger = eventLogger;
            this.mapper = mapper;
            this.fileManagementService = fileManagementService;
        }
        public async Task<ServiceResult<string>> AddUpdate(DeliveryRequest model, long AccountId)
        {
            try
            {
                if (model.Id != 0)
                {
                    var makeobj = await _repository.Delivery.GetByIdAsync(model.Id);
                    if (makeobj == null)
                        return ServiceResults.Errors.NotFound<string>("Delivery", null);

                    makeobj.Name = model.Name;
                    makeobj.PostalCode = model.PostalCode;
                    makeobj.MoveingDate = model.MoveingDate;
                    makeobj.Email = model.Email;
                    makeobj.Phone = model.Phone;
                    makeobj.UpdatedAt = DateTime.UtcNow;
                    _repository.Delivery.Update(makeobj);
                    await _repository.SaveAsync();
                    //_ = emailServices.SendEmailWithPdf(makeobj);
                    return ServiceResults.UpdatedSuccessfully<string>("Delivery");
                }
                else
                {
                    Delivery make = new Delivery()
                    {
                        MoveingDate=model.MoveingDate,
                        PostalCode = model.PostalCode,                        
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        CreatedAt = DateTime.UtcNow,
                    };
                    _repository.Delivery.Create(make);
                    await _repository.SaveAsync();

                    return ServiceResults.AddedSuccessfully<string>("Delivery");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ServiceResult<string>> Delete(long id, long AccountId)
        {
            try
            {
                var makeobj = await _repository.Delivery.GetByIdAsync(id);
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<string>("Delivery", null);
                makeobj.IsDeleted = true;
                makeobj.DeletedAt = DateTime.UtcNow;
                _repository.Delivery.Update(makeobj);
                await _repository.SaveAsync();
                return ServiceResults.DeletedSuccessfully("Delivery");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ServiceResult<Delivery>> GetById(int Id)
        {
            try
            {
                var makeobj = await _repository.Delivery.FindByCondition(a => a.Id == Id).FirstOrDefaultAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<Delivery>("Delivery", null);

                return ServiceResults.GetListSuccessfully(makeobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
