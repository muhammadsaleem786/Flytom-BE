using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Service.Interfaces;
using Logger.Interfaces;
using Repository.Interfaces.Unit;
using Service.Models;
using Microsoft.EntityFrameworkCore;
using DTO.Models;
using Common.Helpers;
using DTO.ViewModel.Vehicle;
using Microsoft.AspNetCore.Http;
using iTextSharp.text.pdf.codec;
using DTO.ViewModel.ContentManagment;

namespace Service.Implementations
{
    internal class ContentManagmentServices : IContentManagmentService
    {
        private readonly IRepositoryUnit _repository;
        private readonly IEmailServices emailServices;
        private readonly IEventLogger eventLogger;
        private readonly IFileManagementService fileManagementService;
        private readonly IMapper mapper;
        public ContentManagmentServices(IRepositoryUnit repository, IEmailServices emailServices, IEventLogger eventLogger, IMapper mapper, IFileManagementService fileManagementService)
        {
            _repository = repository;
            this.emailServices = emailServices;
            this.eventLogger = eventLogger;
            this.mapper = mapper;
            this.fileManagementService = fileManagementService;
        }
        public async Task<ServiceResult<string>> AddUpdate(ContentManagmentRequest model, long AccountId)
        {
            try
            {

                if (model.ID != 0)
                {
                    var obj = await _repository.ContentManagment.GetByIdAsync(model.ID);
                    if (obj == null)
                        return ServiceResults.Errors.NotFound<string>("Content", null);
                    obj.ContentDescription = model.ContentDescription;
                    obj.IsActive = model.IsActive;
                    obj.ContentTypeId =Convert.ToInt64(model.ContentTypeId);                    
                    obj.UpdatedAt = DateTime.UtcNow;                    
                    if (model.BannerList != null)
                    {
                        var imageList = _repository.BannerDetail.FindByCondition(a => a.ContentManagmentId == obj.Id).ToList();
                        if (imageList.Count > 0)
                        {
                            imageList.ForEach(x =>
                            {
                                x.IsDeleted = true; x.DeletedAt = DateTime.UtcNow;
                            });
                            _repository.BannerDetail.UpdateRange(imageList);
                        }
                        List<BannerDetail> listFile = new List<BannerDetail>();
                        foreach (var item in model.BannerList)
                        {
                            listFile.Add(new BannerDetail()
                            {
                                BannerImageUrl = item.BannerImageUrl,
                                BannerDescription=item.BannerDescription,
                                BannerTitle=item.BannerTitle,
                                CreatedAt = DateTime.UtcNow,
                            });
                        }
                        obj.BannerDetail = listFile;
                    }
                    _repository.ContentManagment.Update(obj);
                    await _repository.SaveAsync();
                    return ServiceResults.UpdatedSuccessfully<string>("Content");
                }
                else
                {
                    ContentManagment make = new ContentManagment()
                    {
                        ContentTypeId = Convert.ToInt64(model.ContentTypeId),
                        ContentDescription = model.ContentDescription,
                        IsActive=model.IsActive,
                       CreatedAt=DateTime.UtcNow,
                    };
                    if (model.BannerList != null)
                    {
                        List<BannerDetail> listFile = new List<BannerDetail>();
                        foreach (var item in model.BannerList)
                        {

                            listFile.Add(new BannerDetail()
                            {
                                BannerImageUrl = item.BannerImageUrl,
                                BannerDescription = item.BannerDescription,
                                BannerTitle = item.BannerTitle,
                                CreatedAt = DateTime.UtcNow,
                            });

                        }
                        make.BannerDetail = listFile;
                    }
                    _repository.ContentManagment.Create(make);
                    await _repository.SaveAsync();
                    return ServiceResults.AddedSuccessfully<string>("Content");
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
                var makeobj = await _repository.ContentManagment.GetByIdAsync(id);
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<string>("Content", null);

                var imageList = _repository.BannerDetail.FindByCondition(a => a.ContentManagmentId == makeobj.Id).ToList();
                if (imageList.Count > 0)
                {
                    imageList.ForEach(x =>
                    {
                        x.IsDeleted = true; x.DeletedAt = DateTime.UtcNow;
                    });
                    _repository.BannerDetail.UpdateRange(imageList);
                }

                makeobj.IsDeleted = true;
                makeobj.DeletedAt = DateTime.UtcNow;
                _repository.ContentManagment.Update(makeobj);
                await _repository.SaveAsync();
                return ServiceResults.DeletedSuccessfully("Content");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ServiceResult<ContentManagmentResponse>> GetById(int Id)
        {
            try
            {
                var makeobj = await _repository.ContentManagment.FindByCondition(a => a.Id == Id)
                    .Include(a => a.BannerDetail).Include(a => a.sys_drop_down_value).FirstOrDefaultAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<ContentManagmentResponse>("Content", null);

                var result = new ContentManagmentResponse();
                result.ID = makeobj.Id;
                result.ContentTypeId = makeobj.ContentTypeId;
                result.ContentDescription = makeobj.ContentDescription;
                result.IsActive = makeobj.IsActive;               
                result.BannerList = makeobj.BannerDetail.Where(a => !a.IsDeleted).Select(z => new BannerList
                {
                    Id = z.Id,
                    BannerImageUrl = z.BannerImageUrl,
                    BannerDescription= z.BannerDescription,
                    BannerTitle= z.BannerTitle,
                }).ToList();
                return ServiceResults.GetListSuccessfully(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceResult<List<ContentListManagmentResponse>>> GetList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var makeobj = _repository.ContentManagment.FindAll().Where(a => a.IsDeleted == false).Include(a => a.BannerDetail)
                    .Include(a => a.sys_drop_down_value).AsQueryable();
                if (!string.IsNullOrEmpty(SearchText))
                {
                    makeobj = makeobj.Where(x => x.sys_drop_down_value.Value.ToLower().Contains(SearchText.ToLower()));
                }
                var total = await makeobj.CountAsync();
                makeobj = makeobj.Page(CurrentPageNo, RecordPerPage);
                makeobj = makeobj.OrderByDescending(w => w.CreatedAt);

                var result = makeobj.Select(z => new ContentListManagmentResponse
                {
                    ID = z.Id,
                    ContentTypeId = z.ContentTypeId,
                    ContentDescription = z.ContentDescription,
                    IsActive=z.IsActive,
                    Name=z.sys_drop_down_value.Value,
                    BannerList = z.BannerDetail.Where(a => !a.IsDeleted).Select(z => new BannerList
                    {
                        Id = z.Id,
                        BannerImageUrl = z.BannerImageUrl,
                        BannerDescription= z.BannerDescription,
                        BannerTitle= z.BannerTitle,
                    }).ToList(),
                }).ToList();
                return ServiceResults.GetListSuccessfully<List<ContentListManagmentResponse>>(result, total);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
