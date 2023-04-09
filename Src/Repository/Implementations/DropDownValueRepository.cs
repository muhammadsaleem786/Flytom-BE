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
    internal class DropDownValueRepository : RepositoryBase<sys_drop_down_value>, IDropDownValueRepository
    {

        private readonly FlyttomContext _db;

        public DropDownValueRepository(FlyttomContext db)
            : base(db)
        {
            _db = db;
        }

    }
}
