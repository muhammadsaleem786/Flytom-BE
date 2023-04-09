using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel.Category
{
    public class CategoryResponse
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string CarType { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
