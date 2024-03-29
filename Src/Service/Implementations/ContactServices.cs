﻿using AutoMapper;
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
using DTO.ViewModel.Contact;

namespace Service.Implementations
{
    internal class ContactServices : IContactService
    {
        private readonly IRepositoryUnit _repository;
        private readonly IEmailServices emailServices;
        private readonly IEventLogger eventLogger;
        private readonly IFileManagementService fileManagementService;
        private readonly IMapper mapper;
        public ContactServices(IRepositoryUnit repository, IEmailServices emailServices, IEventLogger eventLogger, IMapper mapper, IFileManagementService fileManagementService)
        {
            _repository = repository;
            this.emailServices = emailServices;
            this.eventLogger = eventLogger;
            this.mapper = mapper;
            this.fileManagementService = fileManagementService;
        }
        public async Task<ServiceResult<string>> AddUpdate(ContactRequest model, long AccountId)
        {
            try
            {
                if (model.ID != 0)
                {
                    var makeobj = await _repository.Contact.GetByIdAsync(model.ID);
                    if (makeobj == null)
                        return ServiceResults.Errors.NotFound<string>("Contact", null);

                    makeobj.Name = model.Name;
                    makeobj.Email = model.Email;
                    makeobj.Phone = model.Phone;
                    makeobj.Description = model.Description;
                    makeobj.ContactType = model.ContactType;
                    makeobj.CompanyName = model.CompanyName;
                    makeobj.EnquiryTypeId = Convert.ToInt64(model.EnquiryTypeId);
                    makeobj.UpdatedAt = DateTime.UtcNow;
                    _repository.Contact.Update(makeobj);
                    await _repository.SaveAsync();
                    _ = emailServices.SendEmailContact(makeobj);
                    return ServiceResults.UpdatedSuccessfully<string>("Contact");
                }
                else
                {
                    Contact make = new Contact()
                    {                      
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        Description=model.Description,
                        EnquiryTypeId=Convert.ToInt64(model.EnquiryTypeId),
                        ContactType=model.ContactType,
                        CreatedAt = DateTime.UtcNow,
                        CompanyName=model.CompanyName,
                    };
                    _repository.Contact.Create(make);
                    await _repository.SaveAsync();
                    var contactobj = await _repository.Contact.FindByCondition(a => a.Id == make.Id)
                       .Include(a => a.sys_drop_down_value).FirstOrDefaultAsync();
                    _ = emailServices.SendEmailContact(contactobj);

                    return ServiceResults.AddedSuccessfully<string>("Contact");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ServiceResult<List<ContactRequest>>> GetContactList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false)
        {
            try
            {
                var makeobj = _repository.Contact.FindAll().Where(a => a.IsDeleted == false).AsQueryable();
                if (!string.IsNullOrEmpty(SearchText))
                {
                    makeobj = makeobj.Where(x => x.Name.ToLower().Contains(SearchText.ToLower()));
                }
                var total = await makeobj.CountAsync();
                makeobj = makeobj.Page(CurrentPageNo, RecordPerPage);
                makeobj = makeobj.OrderByDescending(w => w.CreatedAt);
                var result = makeobj.Select(z => new ContactRequest
                {
                    ID = z.Id,
                    Name = z.Name,
                    Email = z.Email,
                    Phone=z.Phone
                }).ToList();
                return ServiceResults.GetListSuccessfully<List<ContactRequest>>(result, total);
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
                var makeobj = await _repository.Contact.GetByIdAsync(id);
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<string>("Contact", null);
                makeobj.IsDeleted = true;
                makeobj.DeletedAt = DateTime.UtcNow;
                _repository.Contact.Update(makeobj);
                await _repository.SaveAsync();
                return ServiceResults.DeletedSuccessfully("Contact");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ServiceResult<Contact>> GetById(int Id)
        {
            try
            {
                var makeobj = await _repository.Contact.FindByCondition(a => a.Id == Id).FirstOrDefaultAsync();
                if (makeobj == null)
                    return ServiceResults.Errors.NotFound<Contact>("Contact", null);

                return ServiceResults.GetListSuccessfully(makeobj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
