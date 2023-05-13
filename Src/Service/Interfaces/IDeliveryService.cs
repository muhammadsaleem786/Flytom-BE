using DTO.Models;
using DTO.ViewModel.Account;
using DTO.ViewModel.Delivery;
using DTO.ViewModel.Make;
using DTO.ViewModel.Offer;
using DTO.ViewModel.Token;
using Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IDeliveryService
    {
        Task<ServiceResult<Delivery>> GetById(int Id);
        Task<ServiceResult<string>> AddUpdate(DeliveryRequest model, long AccountId);
        Task<ServiceResult<string>> Delete(long id, long AccountId);
    }
}
