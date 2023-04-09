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
using DTO.ViewModel.Category;

namespace Service.Implementations
{
    internal class CategoryServices : ICategoryService
    {
        private readonly IRepositoryUnit _repository;
        private readonly IEmailServices emailServices;
        private readonly IEventLogger eventLogger;
        private readonly IFileManagementService fileManagementService;
        private readonly IMapper mapper;
        public CategoryServices(IRepositoryUnit repository, IEmailServices emailServices, IEventLogger eventLogger, IMapper mapper, IFileManagementService fileManagementService)
        {
            _repository = repository;
            this.emailServices = emailServices;
            this.eventLogger = eventLogger;
            this.mapper = mapper;
            this.fileManagementService = fileManagementService;
        }
        public async Task<ServiceResult<string>> AddUpdate(CategoryRequest model, long AccountId)
        {
            try
            {
                if (model.Id != 0)
                {
                    var makeobj = await _repository.Category.GetByIdAsync(model.Id);
                    if (makeobj == null)
                        return ServiceResults.Errors.NotFound<string>("Category", null);
                    makeobj.Name = model.Name;
                    makeobj.UpdatedAt = DateTime.UtcNow;
                    makeobj.CarType= model.CarType;
                    _repository.Category.Update(makeobj);
                    await _repository.SaveAsync();
                    return ServiceResults.UpdatedSuccessfully<string>("Category");
                }
                else
                {
                    Category make = new Category()
                    {
                        Name = model.Name,
                        CarType= model.CarType,
                        AccountId=AccountId,
                    };
                    _repository.Category.Create(make);
                    await _repository.SaveAsync();
                    return ServiceResults.AddedSuccessfully<string>("Category");
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
                var makeobj = await _repository.Category.GetByIdAsync(id);
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<string>("Category", null);
                makeobj.IsDeleted = true;
                makeobj.DeletedAt = DateTime.UtcNow;
                _repository.Category.Update(makeobj);
                await _repository.SaveAsync();
                return ServiceResults.DeletedSuccessfully("Category");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ServiceResult<Category>> GetById(int Id)
        {
            try
            {
                var makeobj = await _repository.Category.FindByCondition(a=>a.Id==Id).FirstOrDefaultAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<Category>("Category", null);
             
                return ServiceResults.GetListSuccessfully(makeobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ServiceResult<List<CategoryResponse>>> GetCategoryList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var makeobj = _repository.Category.FindAll().Where(a => a.IsDeleted == false).AsQueryable();
                if (!string.IsNullOrEmpty(SearchText))
                {
                    makeobj = makeobj.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()));
                }
                var total = await makeobj.CountAsync();
                makeobj = makeobj.Page(CurrentPageNo, RecordPerPage);
                makeobj = makeobj.OrderByDescending(w => w.CreatedAt);
                var result = makeobj.Select(z => new CategoryResponse
                {
                    ID = z.Id,
                    Name = z.Name,
                    CreatedAt=z.CreatedAt,
                }).ToList();
                return ServiceResults.GetListSuccessfully<List<CategoryResponse>>(result, total);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ServiceResult<List<CategoryResponse>>> GetCategoryList()
        {
            try
            {
                var makeobj = await _repository.Category.FindAll().Where(a => a.IsDeleted == false).ToListAsync();
                var result = makeobj.Select(z => new CategoryResponse
                {
                    ID = z.Id,
                    Name = z.Name
                }).ToList();
                return ServiceResults.GetListSuccessfully<List<CategoryResponse>>(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
