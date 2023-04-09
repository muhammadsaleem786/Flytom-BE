using DTO.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IVehicleModelsRepository : IRepositoryBase<VehicleModels>
    {
        Task<VehicleModels> GetByIdAsync(long id);
    }
}
