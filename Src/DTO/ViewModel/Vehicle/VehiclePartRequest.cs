using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel.Vehicle
{
    public class VehiclePartRequest
    {
        public long Id { get; set; }
        public long DropDownId { get; set; }
        public bool IsChecked { get; set; }

    }
}
