using DTO.Models;
using DTO.ViewModel.Contact;
using DTO.ViewModel.Make;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IContactService
    {
        Task<ServiceResult<Contact>> GetById(int Id);
        Task<ServiceResult<string>> AddUpdate(ContactRequest model, long AccountId);
        Task<ServiceResult<string>> Delete(long id, long AccountId);
        Task<ServiceResult<List<ContactRequest>>> GetContactList(decimal AccountId, int CurrentPageNo, int RecordPerPage, string VisibleColumnInfo, string SortName, string SortOrder, string SearchText, bool IgnorePaging = false);

    }
}
