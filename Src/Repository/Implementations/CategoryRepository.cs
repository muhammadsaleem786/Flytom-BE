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
    internal class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {

        private readonly FlyttomContext _db;

        public CategoryRepository(FlyttomContext db)
            : base(db)
        {
            _db = db;
        }


        public async Task<Category> GetByIdAsync(long id)
        {
            return await FindByCondition(f => f.Id == id).FirstOrDefaultAsync();
        }
    }
}
