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

namespace Service.Implementations
{
    internal class OfferServices : IOfferService
    {
        private readonly IRepositoryUnit _repository;
        private readonly IEmailServices emailServices;
        private readonly IEventLogger eventLogger;
        private readonly IFileManagementService fileManagementService;
        private readonly IMapper mapper;
        public OfferServices(IRepositoryUnit repository, IEmailServices emailServices, IEventLogger eventLogger, IMapper mapper, IFileManagementService fileManagementService)
        {
            _repository = repository;
            this.emailServices = emailServices;
            this.eventLogger = eventLogger;
            this.mapper = mapper;
            this.fileManagementService = fileManagementService;
        }
        public async Task<ServiceResult<string>> AddUpdate(OfferRequest model, long AccountId)
        {
            try
            {
                if (model.Id != 0)
                {
                    var makeobj = await _repository.Offer.GetByIdAsync(model.Id);
                    if (makeobj == null)
                        return ServiceResults.Errors.NotFound<string>("Offer", null);
                    makeobj.Name = model.Name;
                    makeobj.UpdatedAt = DateTime.UtcNow;
                    _repository.Offer.Update(makeobj);
                    await _repository.SaveAsync();
                    return ServiceResults.UpdatedSuccessfully<string>("Offer");
                }
                else
                {
                    Offer make = new Offer()
                    {
                        Name = model.Name,
                    };
                    _repository.Offer.Create(make);
                    await _repository.SaveAsync();
                    _ = emailServices.SendEmailWithPdf(model.Name, model.Email);
                    return ServiceResults.AddedSuccessfully<string>("Offer");
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
                var makeobj = await _repository.Offer.GetByIdAsync(id);
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<string>("Offer", null);
                makeobj.IsDeleted = true;
                makeobj.DeletedAt = DateTime.UtcNow;
                _repository.Offer.Update(makeobj);
                await _repository.SaveAsync();
                return ServiceResults.DeletedSuccessfully("Offer");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ServiceResult<Offer>> GetById(int Id)
        {
            try
            {
                var makeobj = await _repository.Offer.FindByCondition(a=>a.Id==Id).FirstOrDefaultAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<Offer>("Offer", null);
             
                return ServiceResults.GetListSuccessfully(makeobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
