using DTO.Models;
using DTO.ViewModel.Account;
using DTO.ViewModel.Make;
using DTO.ViewModel.Model;
using DTO.ViewModel.Token;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IVehicleModelService
    {
        Task<ServiceResult<List<ModelResponseList>>> GetModelList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false);
        Task<ServiceResult<List<ModelResponseList>>> GetModelList();
        Task<ServiceResult<string>> AddUpdate(ModelRequest model, long AccountId);
        Task<ServiceResult<string>> Delete(long id, long AccountId);
        Task<ServiceResult<VehicleModels>> GetById(int Id);
        Task<ServiceResult<List<ModelResponseList>>> LoadModelByMakeId(int Id);
    }
}
