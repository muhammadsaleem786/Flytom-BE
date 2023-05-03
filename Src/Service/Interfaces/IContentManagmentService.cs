using DTO.Models;
using DTO.ViewModel.Account;
using DTO.ViewModel.ContentManagment;
using DTO.ViewModel.Make;
using DTO.ViewModel.Token;
using DTO.ViewModel.Vehicle;
using Microsoft.AspNetCore.Http;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IContentManagmentService
    {
        Task<ServiceResult<string>> AddUpdate(ContentManagmentRequest model, long AccountId);
        Task<ServiceResult<string>> Delete(long id, long AccountId);
        Task<ServiceResult<List<ContentManagmentResponse>>> GetList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false);
        Task<ServiceResult<ContentManagmentResponse>> GetById(int Id);
    }
}
