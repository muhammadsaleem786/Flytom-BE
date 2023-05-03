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
    internal class BannerDetailRepository : RepositoryBase<BannerDetail>, IBannerDetailRepository
    {

        private readonly FlyttomContext _db;

        public BannerDetailRepository(FlyttomContext db)
            : base(db)
        {
            _db = db;
        }

    }
}
