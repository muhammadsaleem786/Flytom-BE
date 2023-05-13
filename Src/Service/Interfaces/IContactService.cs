using DTO.Models;
using DTO.ViewModel.Contact;
using Service.Models;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IContactService
    {
        Task<ServiceResult<Contact>> GetById(int Id);
        Task<ServiceResult<string>> AddUpdate(ContactRequest model, long AccountId);
        Task<ServiceResult<string>> Delete(long id, long AccountId);
    }
}
