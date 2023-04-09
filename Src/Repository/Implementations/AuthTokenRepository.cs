﻿using Microsoft.EntityFrameworkCore;
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
    internal class AuthTokenRepository : RepositoryBase<AuthToken>, IAuthTokenRepository
    {


        private readonly FlyttomContext _db;


        public AuthTokenRepository(FlyttomContext db)
            : base(db)
        {
            _db = db;
        }
        public AuthToken GetById(long id)
        {
            return FindByCondition(f => !f.IsDeleted && f.Id == id).FirstOrDefault();
        }

        public AuthToken GetByToken(string token)
        {
            return FindByCondition(f => !f.IsDeleted && f.Token.Equals(token)).FirstOrDefault();
        }
        public AuthToken GetTokenByWeb(string token, bool Isweb)
        {
            return FindByCondition(f => !f.IsDeleted && f.Token.Equals(token) && f.IsWeb.Equals(Isweb)).FirstOrDefault();
        }

        public AuthToken GetByUuid(Guid uuid)
        {
            return FindByCondition(f => !f.IsDeleted && f.Uuid == uuid).FirstOrDefault();
        }
        public AuthToken GetByAccountId(long id)
        {
            return FindByCondition(f => !f.IsDeleted && f.AccountId == id).FirstOrDefault();
        }
        public bool AnyByToken(string token)
        {
            return FindByCondition(f => !f.IsDeleted && f.Token.Equals(token)).Any();
        }
        public async Task<AuthToken> GetByTokenAsync(string token)
        {
            return await FindByCondition(f => !f.IsDeleted && f.Token.Equals(token)).FirstOrDefaultAsync();
        }
        public async Task DisableAllSessions(long accountId)
        {
            foreach (var item in await FindByConditionWithTracking(f => f.IsDeleted == false && f.IsLogout == false && f.Account.Id == accountId).ToListAsync())
            {
                item.IsLogout = true;
                item.LogoutAt = DateTime.UtcNow;
            }
        }
    }
}
