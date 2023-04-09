using DTO.Models;
using DTO.ViewModel.Account;
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
    public interface IVehicleService
    {
        Task<ServiceResult<string>> AddUpdate(VehicleRequest model, long AccountId);
        Task<ServiceResult<string>> Delete(long id, long AccountId);
        Task<ServiceResult<List<VehicleResponseModel>>> GetVehicleList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false);
        Task<ServiceResult<List<VehicleResponseModel>>> GetWebVehicleList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string SortOrder, string SearchText,string Type);
        Task<ServiceResult<VehicleResponse>> GetById(int Id);
        Task<ServiceResult<List<ImageList>>> UploadImage(List<IFormFile> ImageList);
        Task<ServiceResult<VehicleWebResponse>> GetByIdWebSite(int Id,string Type);
    }
}
