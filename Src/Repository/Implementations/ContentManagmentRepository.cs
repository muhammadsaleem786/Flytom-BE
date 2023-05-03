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
    internal class ContentManagmentRepository : RepositoryBase<ContentManagment>, IContentManagmentRepository
    {

        private readonly FlyttomContext _db;

        public ContentManagmentRepository(FlyttomContext db)
            : base(db)
        {
            _db = db;
        }


        public async Task<ContentManagment> GetByIdAsync(long id)
        {
            return await FindByCondition(f => f.Id == id).FirstOrDefaultAsync();
        }
    }
}
