using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Models;
using Context;
using Repository.Interfaces;
using Repository.Implementations.Base;

namespace Repository.Implementations
{
    internal class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {

        private readonly FlyttomContext _db;

        public AccountRepository(FlyttomContext db)
            : base(db)
        {
            _db = db;
        }


        public async Task<Account> GetByIdAsync(long id)
        {
            return await FindByCondition(f => f.Id == id).FirstOrDefaultAsync();
        }
        public Account GetAccountByPhoneNumber(string phoneNumber)
        {
            return FindByCondition(f => f.PhoneNumber == phoneNumber).FirstOrDefault();
        }
        public async Task<Account> GetAccountByPhoneNumberAsync(string phoneNumber)
        {
            return await FindByCondition(f => f.PhoneNumber.ToLower().Equals(phoneNumber.ToLower())).FirstOrDefaultAsync();
        }

        public async Task<Account> GetByUuidAsync(Guid uuid)
        {
            return await FindByCondition(f => f.Uuid == uuid).FirstOrDefaultAsync();
        }

        public bool AnyAccountByEmail(string email)
        {
            return FindByCondition(f => f.Email.Equals(email)).Any();
        }

        public bool AnyAccountByEmail(string email, long id)
        {
            return FindByCondition(f => f.Email.Equals(email) && f.Id != id).Any();
        }

        public bool AnyAccountByPhoneNumber(string phoneNumber)
        {
            return FindByCondition(f => f.PhoneNumber.Equals(phoneNumber)).Any();
        }

        public bool AnyAccountByPhoneNumber(string phoneNumber, long id)
        {
            return FindByCondition(f => f.PhoneNumber.Equals(phoneNumber) && f.Id != id).Any();
        }
        public async Task<Account> GetAccountByAddressAsync(string address)
        {
            return await FindByCondition(f => f.Address.Equals(address)).FirstOrDefaultAsync();
        }
        public Account GetAccountByEmail(string email)
        {
            return FindByCondition(f => f.Email.Equals(email)).FirstOrDefault();
        }

        public Account GetAccountByEmail(string email, string password)
        {
            return FindByCondition(f => f.Email.Equals(email) && f.Password.Equals(password) && f.IsEmailVerified==true).FirstOrDefault();
        }

        //public Account GetAccountByPhoneNumber(string phoneNumber)
        //{
        //    return FindByCondition(f => f.PhoneNumber.Equals(phoneNumber)).FirstOrDefault();
        //}

        public Account GetAccount(long id)
        {
            return FindByCondition(f => f.Id == id).FirstOrDefault();
        }
    }
}
