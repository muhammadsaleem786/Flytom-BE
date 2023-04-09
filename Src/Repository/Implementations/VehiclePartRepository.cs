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
    internal class VehiclePartRepository : RepositoryBase<VehiclePart>, IVehiclePartRepository
    {

        private readonly FlyttomContext _db;

        public VehiclePartRepository(FlyttomContext db)
            : base(db)
        {
            _db = db;
        }

    }
}
