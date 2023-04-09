using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class VehicleImage:CommonDbProp
    {
        public string ImageURL { get; set; }
        public long VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
