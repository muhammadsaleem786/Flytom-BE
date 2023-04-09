using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class VehiclePart:CommonDbProp
    {
        public long VehicleId { get; set; }
        public long DropDownId { get; set; }
        public bool IsChecked { get; set; }
        public Vehicle Vehicle { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value { get; set; }

    }
}
