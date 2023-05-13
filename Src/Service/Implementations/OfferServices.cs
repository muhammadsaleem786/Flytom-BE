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
                    makeobj.IsPacking = Convert.ToBoolean(model.IsPacking);
                    makeobj.MovingDate = model.MovingDate;
                    makeobj.IsWarehousehotel = Convert.ToBoolean(model.IsWarehousehotel);
                    makeobj.Ispiano = Convert.ToBoolean(model.Ispiano);
                    makeobj.CurrentAddress = model.CurrentAddress;
                    makeobj.StreetNo = model.StreetNo;
                    makeobj.PostalCode = model.PostalCode;
                    makeobj.SizeOfHome = model.SizeOfHome;
                    makeobj.TotalRoomId = Convert.ToInt64(model.TotalRoomId);
                    makeobj.HouseTypeId = Convert.ToInt64(model.HouseTypeId);
                    makeobj.FloorTypeId = Convert.ToInt64(model.FloorTypeId);
                    makeobj.garage = model.garage;
                    makeobj.ParkingDistance = model.ParkingDistance;
                    makeobj.NewAddress = model.NewAddress;
                    makeobj.NewStreetNo = model.NewStreetNo;
                    makeobj.NewPostalCode = model.NewPostalCode;
                    makeobj.NewSizeOfHome = model.NewSizeOfHome;
                    makeobj.NewTotalRoomId = Convert.ToInt64(model.NewTotalRoomId);
                    makeobj.NewHouseTypeId = Convert.ToInt64(model.NewHouseTypeId);
                    makeobj.NewFloorTypeId = Convert.ToInt64(model.NewFloorTypeId);
                    makeobj.Newgarage = model.Newgarage;
                    makeobj.NewParkingDistance = model.NewParkingDistance;
                    makeobj.AdditionalInfo = model.AdditionalInfo;
                    makeobj.Name = model.Name;
                    makeobj.Email = model.Email;
                    makeobj.Phone = model.Phone;
                    makeobj.UpdatedAt = DateTime.UtcNow;
                    _repository.Offer.Update(makeobj);
                    await _repository.SaveAsync();
                    _ = emailServices.SendEmailWithPdf(makeobj);
                    return ServiceResults.UpdatedSuccessfully<string>("Offer");
                }
                else
                {
                    MovingOffer make = new MovingOffer()
                    {
                        IsPacking = Convert.ToBoolean(model.IsPacking),
                        MovingDate = model.MovingDate,
                        IsWarehousehotel = Convert.ToBoolean(model.IsWarehousehotel),
                        Ispiano = Convert.ToBoolean(model.Ispiano),
                        CurrentAddress = model.CurrentAddress,
                        StreetNo = model.StreetNo,
                        PostalCode = model.PostalCode,
                        SizeOfHome = model.SizeOfHome,
                        TotalRoomId = Convert.ToInt64(model.TotalRoomId),
                        HouseTypeId = Convert.ToInt64(model.HouseTypeId),
                        FloorTypeId = Convert.ToInt64(model.FloorTypeId),
                        garage = model.garage,
                        ParkingDistance = model.ParkingDistance,
                        NewAddress = model.NewAddress,
                        NewStreetNo = model.NewStreetNo,
                        NewPostalCode = model.NewPostalCode,
                        NewSizeOfHome = model.NewSizeOfHome,
                        NewTotalRoomId = Convert.ToInt64(model.NewTotalRoomId),
                        NewHouseTypeId = Convert.ToInt64(model.NewHouseTypeId),
                        NewFloorTypeId = Convert.ToInt64(model.NewFloorTypeId),
                        Newgarage = model.Newgarage,
                        NewParkingDistance = model.NewParkingDistance,
                        AdditionalInfo = model.AdditionalInfo,
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        CreatedAt = DateTime.UtcNow,
                    };
                    _repository.Offer.Create(make);
                    await _repository.SaveAsync();
                    var offerobj = await _repository.Offer.FindByCondition(a => a.Id == make.Id)
                        .Include(a => a.sys_drop_down_value).Include(a => a.sys_drop_down_value1).Include(a => a.sys_drop_down_value2)
                        .Include(a => a.sys_drop_down_value3).Include(a => a.sys_drop_down_value4).Include(a => a.sys_drop_down_value5)
                        .FirstOrDefaultAsync();
                    _ = emailServices.SendEmailWithPdf(offerobj);
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

        public async Task<ServiceResult<MovingOffer>> GetById(int Id)
        {
            try
            {
                var makeobj = await _repository.Offer.FindByCondition(a => a.Id == Id).FirstOrDefaultAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<MovingOffer>("Offer", null);

                return ServiceResults.GetListSuccessfully(makeobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
