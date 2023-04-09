using DTO.Models;
using DTO.ViewModel.Account;
using DTO.ViewModel.Make;
using DTO.ViewModel.Token;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMakeService
    {
        Task<ServiceResult<List<MakeResponseList>>> GetMakesList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false);
        Task<ServiceResult<Makes>> GetById(int Id);
        Task<ServiceResult<string>> AddUpdate(MakeRequest model, long AccountId);
        Task<ServiceResult<string>> Delete(long id, long AccountId);
        Task<ServiceResult<List<MakeResponseList>>> GetMakesList();

    }
}
