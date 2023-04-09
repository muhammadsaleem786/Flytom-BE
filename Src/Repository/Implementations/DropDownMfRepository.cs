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
    internal class DropDownMfRepository : RepositoryBase<sys_drop_down_mf>, IDropDownMfRepository
    {

        private readonly FlyttomContext _db;

        public DropDownMfRepository(FlyttomContext db)
            : base(db)
        {
            _db = db;
        }

    }
}
