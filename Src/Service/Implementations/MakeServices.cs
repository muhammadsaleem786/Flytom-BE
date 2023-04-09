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
    internal class MakeServices : IMakeService
    {
        private readonly IRepositoryUnit _repository;
        private readonly IEmailServices emailServices;
        private readonly IEventLogger eventLogger;
        private readonly IFileManagementService fileManagementService;
        private readonly IMapper mapper;
        public MakeServices(IRepositoryUnit repository, IEmailServices emailServices, IEventLogger eventLogger, IMapper mapper, IFileManagementService fileManagementService)
        {
            _repository = repository;
            this.emailServices = emailServices;
            this.eventLogger = eventLogger;
            this.mapper = mapper;
            this.fileManagementService = fileManagementService;
        }
        public async Task<ServiceResult<string>> AddUpdate(MakeRequest model, long AccountId)
        {
            try
            {
                if (model.Id != 0)
                {
                    var makeobj = await _repository.Makes.GetByIdAsync(model.Id);
                    if (makeobj == null)
                        return ServiceResults.Errors.NotFound<string>("Make", null);
                    makeobj.Name = model.Name;
                    makeobj.UpdatedAt = DateTime.UtcNow;
                    _repository.Makes.Update(makeobj);
                    await _repository.SaveAsync();
                    return ServiceResults.UpdatedSuccessfully<string>("Make");
                }
                else
                {
                    Makes make = new Makes()
                    {
                        Name = model.Name,
                        AccountId=AccountId,
                    };
                    _repository.Makes.Create(make);
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
                var makeobj = await _repository.Makes.GetByIdAsync(id);
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<string>("Make", null);
                makeobj.IsDeleted = true;
                makeobj.DeletedAt = DateTime.UtcNow;
                _repository.Makes.Update(makeobj);
                await _repository.SaveAsync();
                return ServiceResults.DeletedSuccessfully("Make");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ServiceResult<Makes>> GetById(int Id)
        {
            try
            {
                var makeobj = await _repository.Makes.FindByCondition(a=>a.Id==Id).FirstOrDefaultAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<Makes>("Make", null);
             
                return ServiceResults.GetListSuccessfully(makeobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ServiceResult<List<MakeResponseList>>> GetMakesList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var makeobj = _repository.Makes.FindAll().Where(a => a.IsDeleted == false).AsQueryable();
                if (!string.IsNullOrEmpty(SearchText))
                {
                    makeobj = makeobj.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()));
                }
                var total = await makeobj.CountAsync();
                makeobj = makeobj.Page(CurrentPageNo, RecordPerPage);
                makeobj = makeobj.OrderByDescending(w => w.CreatedAt);
                var result = makeobj.Select(z => new MakeResponseList
                {
                    ID = z.Id,
                    Name = z.Name,
                    CreatedAt = z.CreatedAt,
                }).ToList();
                return ServiceResults.GetListSuccessfully<List<MakeResponseList>>(result, total);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ServiceResult<List<MakeResponseList>>> GetMakesList()
        {
            try
            {
                var makeobj = await _repository.Makes.FindAll().Where(a => a.IsDeleted == false).ToListAsync();
                var result = makeobj.Select(z => new MakeResponseList
                {
                    ID = z.Id,
                    Name = z.Name
                }).ToList();
                return ServiceResults.GetListSuccessfully<List<MakeResponseList>>(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
