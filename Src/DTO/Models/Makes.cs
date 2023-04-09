using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Makes:CommonDbProp
    {
        public Makes()
        {
            VehicleModels = new HashSet<VehicleModels>();
        }
        public string Name { get; set; }
        public long AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<VehicleModels> VehicleModels { get; set; }
    }
}
