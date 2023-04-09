using DTO.Enums;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel.Vehicle
{
    public class VehicleResponse
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long MakesId { get; set; }
        public long VehicleModelsId { get; set; }
        public long CategoryId { get; set; }
        public long FuelTypeId { get; set; }
        public long TankCapacity { get; set; }
        public long NoOfDoor { get; set; }
        public long NoOfSeatId { get; set; }
        public string Description { get; set; }
        public long SequreFeetId { get; set; }
        public string LoadCapacity { get; set; }
        public long RangeGiven { get; set; }
        public string Lift { get; set; }

        public long DriveWheelType { get; set; }
        public string CarType { get; set; }
        public long LicenceType { get; set; }
        public long SteeringTypeId { get; set; }
        public long Length { get; set; }
        public long Height { get; set; }
        public long Width { get; set; }
        public virtual ICollection<VehicleImageResponse> VehicleImage { get; set; }
        public virtual ICollection<VehiclePartRequest> VehiclePartRequest { get; set; }

    }
}
