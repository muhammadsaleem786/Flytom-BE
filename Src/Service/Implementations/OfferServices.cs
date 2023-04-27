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
                    makeobj.MovingDate = model.MovingDate;
                    makeobj.IsFlexible = model.IsFlexible;
                    makeobj.DesiredMovingDate = model.DesiredMovingDate;
                    makeobj.IsPackedItem = model.IsPackedItem;
                    makeobj.IsStoreObject = model.IsStoreObject;
                    makeobj.IsCurrentHome = model.IsCurrentHome;
                    makeobj.IsInsureMoving = model.IsInsureMoving;
                    makeobj.MovingLoad = model.MovingLoad;
                    makeobj.NoOfPeople = model.NoOfPeople;
                    makeobj.CurrentAddress = model.CurrentAddress;
                    makeobj.StreetNo = model.StreetNo;
                    makeobj.SizeOfHome = model.SizeOfHome;
                    makeobj.TotalRoom = model.TotalRoom;
                    makeobj.HouseType = model.HouseType;
                    makeobj.IsMovedStorageRoom = model.IsMovedStorageRoom;
                    makeobj.IsMovedGarage = model.IsMovedGarage;
                    makeobj.ParkingDistance = model.ParkingDistance;
                    makeobj.NewAddress = model.NewAddress;
                    makeobj.NewStreetNo = model.NewStreetNo;
                    makeobj.PostalCode = model.PostalCode;
                    makeobj.NewTotalRoom = model.NewTotalRoom;
                    makeobj.NewHouseType = model.NewHouseType;
                    makeobj.ApartmentFloor = model.ApartmentFloor;
                    makeobj.IsLift = model.IsLift;
                    makeobj.NewParkingDistance = model.NewParkingDistance;
                    makeobj.IsMovingHeavyObject = model.IsMovingHeavyObject;
                    makeobj.IsMovingValueableItem = model.IsMovingValueableItem;
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
                    Offer make = new Offer()
                    {
                        MovingDate = model.MovingDate,
                        IsFlexible = model.IsFlexible,
                        DesiredMovingDate = model.DesiredMovingDate,
                        IsPackedItem = model.IsPackedItem,
                        IsStoreObject = model.IsStoreObject,
                        IsCurrentHome = model.IsCurrentHome,
                        IsInsureMoving = model.IsInsureMoving,
                        MovingLoad = model.MovingLoad,
                        NoOfPeople = model.NoOfPeople,
                        CurrentAddress = model.CurrentAddress,
                        StreetNo = model.StreetNo,
                        SizeOfHome = model.SizeOfHome,
                        TotalRoom = model.TotalRoom,
                        HouseType = model.HouseType,
                        IsMovedStorageRoom = model.IsMovedStorageRoom,
                        IsMovedGarage = model.IsMovedGarage,
                        ParkingDistance = model.ParkingDistance,
                        NewAddress = model.NewAddress,
                        NewStreetNo = model.NewStreetNo,
                        PostalCode = model.PostalCode,
                        NewTotalRoom = model.NewTotalRoom,
                        NewHouseType = model.NewHouseType,
                        ApartmentFloor = model.ApartmentFloor,
                        IsLift = model.IsLift,
                        NewParkingDistance = model.NewParkingDistance,
                        IsMovingHeavyObject = model.IsMovingHeavyObject,
                        IsMovingValueableItem = model.IsMovingValueableItem,
                        AdditionalInfo = model.AdditionalInfo,
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                    };
                    _repository.Offer.Create(make);
                    await _repository.SaveAsync();
                    _ = emailServices.SendEmailWithPdf(make);
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
                var makeobj = await _repository.Offer.FindByCondition(a => a.Id == Id).FirstOrDefaultAsync();
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
