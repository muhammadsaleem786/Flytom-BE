using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Category:CommonDbProp
    {
        public Category()
        {
            Vehicle = new HashSet<Vehicle>();
        }
        public long AccountId { get; set; }
        public virtual Account Account { get; set; }
        public string CarType { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }

    }
}
