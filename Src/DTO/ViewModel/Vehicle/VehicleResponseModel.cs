using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel.Vehicle
{
    public class VehicleResponseModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long MakeId { get; set; }
        public long ModelId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public string FuelType { get; set; }
        public string TotalSeat { get; set; }
        public long TankCapacity { get; set; }
        public long NoOfDoor { get; set; }
        public long NoOfSeat { get; set; }
        public string Description { get; set; }
        public long DriveWheelType { get; set; }
        public string CarType { get; set; }
        public string Capacity { get; set; }
        public string SteeringType { get; set; }
        public long Length { get; set; }
        public long Height { get; set; }
        public long Width { get; set; }
        public string CarImage { get; set; }
        public virtual ICollection<VehicleImageResponse> VehicleImage { get; set; }
        public virtual ICollection<VehiclePartRequest> VehiclePartRequest { get; set; }
    }
}
