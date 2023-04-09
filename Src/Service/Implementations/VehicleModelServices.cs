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
using DTO.ViewModel.Model;
using iTextSharp.text;

namespace Service.Implementations
{
    internal class VehicleModelServices : IVehicleModelService
    {
        private readonly IRepositoryUnit _repository;
        private readonly IEmailServices emailServices;
        private readonly IEventLogger eventLogger;
        private readonly IFileManagementService fileManagementService;
        private readonly IMapper mapper;
        public VehicleModelServices(IRepositoryUnit repository, IEmailServices emailServices, IEventLogger eventLogger, IMapper mapper, IFileManagementService fileManagementService)
        {
            _repository = repository;
            this.emailServices = emailServices;
            this.eventLogger = eventLogger;
            this.mapper = mapper;
            this.fileManagementService = fileManagementService;
        }
        public async Task<ServiceResult<string>> AddUpdate(ModelRequest model, long AccountId)
        {
            try
            {
                if (model.Id != 0)
                {
                    var obj = await _repository.VehicleModels.GetByIdAsync(model.Id);
                    if (obj == null)
                        return ServiceResults.Errors.NotFound<string>("Make", null);
                    obj.Name = model.Name;
                    obj.MakeId = model.MakeId;
                    obj.UpdatedAt = DateTime.UtcNow;
                    _repository.VehicleModels.Update(obj);
                    await _repository.SaveAsync();
                    return ServiceResults.UpdatedSuccessfully<string>("Make");
                }
                else
                {
                    VehicleModels make = new VehicleModels()
                    {
                        Name = model.Name,
                        MakeId = model.MakeId,
                        AccountId = AccountId,
                    };
                    _repository.VehicleModels.Create(make);
                    await _repository.SaveAsync();
                    return ServiceResults.AddedSuccessfully<string>("Make");
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
                var makeobj = await _repository.VehicleModels.GetByIdAsync(id);
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<string>("Model", null);
                makeobj.IsDeleted = true;
                makeobj.DeletedAt = DateTime.UtcNow;
                _repository.VehicleModels.Update(makeobj);
                await _repository.SaveAsync();
                return ServiceResults.DeletedSuccessfully("Make");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ServiceResult<List<ModelResponseList>>> GetModelList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var makeobj =  _repository.VehicleModels.FindAll().Where(a => a.IsDeleted == false).Include(a=>a.Makes).AsQueryable();
                if (!string.IsNullOrEmpty(SearchText))
                {
                    makeobj = makeobj.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()));
                }
                var total = await makeobj.CountAsync();
                makeobj = makeobj.Page(CurrentPageNo, RecordPerPage);
                makeobj = makeobj.OrderByDescending(w => w.CreatedAt);
                var result = makeobj.Select(z => new ModelResponseList
                {
                    ID = z.Id,
                    Name = z.Name,
                    MakeName = z.Makes.Name
                }).ToList();
                return ServiceResults.GetListSuccessfully<List<ModelResponseList>>(result, total);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ServiceResult<VehicleModels>> GetById(int Id)
        {
            try
            {
                var makeobj = await _repository.VehicleModels.FindByCondition(a => a.Id == Id).FirstOrDefaultAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<VehicleModels>("Make", null);

                return ServiceResults.GetListSuccessfully(makeobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<ServiceResult<List<ModelResponseList>>> LoadModelByMakeId(int Id)
        {
            try
            {
                var makeobj = await _repository.VehicleModels.FindByCondition(a => a.MakeId == Id && a.IsDeleted==false).ToListAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<List<ModelResponseList>>("Model", null);

                var reslt = makeobj.Select(a => new ModelResponseList
                {
                    ID=a.Id,
                    Name=a.Name,
                }).ToList();
                return ServiceResults.GetListSuccessfully(reslt);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ServiceResult<List<ModelResponseList>>> GetModelList()
        {
            try
            {
                var makeobj = await _repository.VehicleModels.FindAll().Where(a => a.IsDeleted == false).ToListAsync();
                var result = makeobj.Select(z => new ModelResponseList
                {
                    ID = z.Id,
                    Name = z.Name
                }).ToList();
                return ServiceResults.GetListSuccessfully<List<ModelResponseList>>(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
