using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel.Vehicle
{
    public class VehicleWebResponse
    {
       
        public long TankCapacity { get; set; }
        public long NoOfDoor { get; set; }       
        public string Description { get; set; }
        public string LoadCapacity { get; set; }
        public long RangeGiven { get; set; }
        public string Lift { get; set; }
        public string CarType { get; set; }
        public long Length { get; set; }
        public long Height { get; set; }
        public long Width { get; set; }
        public string FuelType { get; set; }
        public string WheelType { get; set; }
        public string Licence { get; set; }
        public string SteeringType { get; set; }
        public string TotalSeat { get; set; }
        public string SequreFeet { get; set; }
        public string Category { get; set; }
        public virtual ICollection<VehicleImageResponse> VehicleImage { get; set; }
        public virtual ICollection<VehiclePartRequest> VehiclePartRequest { get; set; }

    }
}
