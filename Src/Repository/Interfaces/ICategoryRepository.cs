using DTO.Models;
using Repository.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<Category> GetByIdAsync(long id);
    }
}
