using DTO.Models;
using Repository.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        Task<Account> GetByIdAsync(long id);
        Task<Account> GetByUuidAsync(Guid uuid);
        Account GetAccount(long id);
        Account GetAccountByPhoneNumber(string phoneNumber);
        bool AnyAccountByPhoneNumber(string phoneNumber);
        bool AnyAccountByPhoneNumber(string phoneNumber, long id);
        Task<Account> GetAccountByAddressAsync(string address);
        Account GetAccountByEmail(string email, string password);
        Account GetAccountByEmail(string email);
        bool AnyAccountByEmail(string email);
        bool AnyAccountByEmail(string email, long id);
        Task<Account> GetAccountByPhoneNumberAsync(string phoneNumber);
    }
}
