using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Vehicle:CommonDbProp
    {
        public Vehicle()
        {
            VehicleImage = new HashSet<VehicleImage>();
            VehiclePart= new HashSet<VehiclePart>();
        }
        public long AccountId { get; set; }
        public long MakesId { get; set; }
        public long CategoryId { get; set; }
        public long VehicleModelsId { get; set; }
        public long FuelTypeId { get; set; }
        public long TankCapacity { get; set; }
        public long NoOfDoor { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
        public long Height { get; set; }
        public long Width { get; set; }
        public long NoOfSeatId { get; set; }
        public string Description { get; set; }
        public long DriveWheelType { get; set; }
        public string CarType { get; set; }
        public Nullable<long> RangeGiven { get; set; }
        public string LoadCapacity { get; set; }
        public string Lift { get; set; }
        public long LicenceType { get; set; }
        public long? SequreFeetId { get; set; }
        public long SteeringTypeId { get; set; }
        public virtual Makes Makes { get; set; }
        public virtual VehicleModels VehicleModels { get; set; }
        public virtual Account Account { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value1 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value2 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value3 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value4 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value5 { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<VehiclePart> VehiclePart { get; set; }
        public virtual ICollection<VehicleImage> VehicleImage { get; set; }
    }
}
