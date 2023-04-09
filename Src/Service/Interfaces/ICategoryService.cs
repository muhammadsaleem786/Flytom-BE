using DTO.Models;
using DTO.ViewModel.Account;
using DTO.ViewModel.Category;
using DTO.ViewModel.Make;
using DTO.ViewModel.Token;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResult<List<CategoryResponse>>> GetCategoryList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false);
        Task<ServiceResult<Category>> GetById(int Id);
        Task<ServiceResult<string>> AddUpdate(CategoryRequest model, long AccountId);
        Task<ServiceResult<string>> Delete(long id, long AccountId);
        Task<ServiceResult<List<CategoryResponse>>> GetCategoryList();

    }
}
