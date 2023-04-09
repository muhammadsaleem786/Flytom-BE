using DTO.Models;
using DTO.ViewModel.Account;
using DTO.ViewModel.Make;
using DTO.ViewModel.Offer;
using DTO.ViewModel.Token;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IOfferService
    {
        Task<ServiceResult<Offer>> GetById(int Id);
        Task<ServiceResult<string>> AddUpdate(OfferRequest model, long AccountId);
        Task<ServiceResult<string>> Delete(long id, long AccountId);
    }
}
