using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class VehicleModels:CommonDbProp
    {
        public long AccountId { get; set; }
        public string Name { get; set; }
        public long MakeId { get; set; }
        public Makes Makes { get; set; }
        public virtual Account Account { get; set; }
    }
}
