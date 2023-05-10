using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Offer : CommonDbProp
    {
        public String DesiredMovingDate { get; set; }
        public long FlexibleMovingDateId { get; set; }
        public Boolean IsFlexible { get; set; }
        public Boolean IsPackedItem { get; set; }
        public Boolean IsStoreObject { get; set; }
        public Boolean IsCurrentHome { get; set; }
        public Boolean IsInsureMoving { get; set; }
        public long MovingLoadId { get; set; }
        public long NoOfPeopleId { get; set; }
        public String CurrentAddress { get; set; }
        public String StreetNo { get; set; }
        public String SizeOfHome { get; set; }
        public String PostalCode { get; set; }
        public long TotalRoomId { get; set; }
        public long HouseTypeId { get; set; }
        public long EmployeeId { get; set; }
        public Boolean IsMovedStorageRoom { get; set; }
        public Boolean IsMovedGarage { get; set; }
        public String ParkingDistance { get; set; }
        public long FloorTypeId { get; set; }
        public String NewAddress { get; set; }
        public String NewStreetNo { get; set; }
        public String NewPostalCode { get; set; }
        public long NewTotalRoomId { get; set; }
        public long NewHouseTypeId { get; set; }
        public String NewSizeOfHome { get; set; }
        public String NewParkingDistance { get; set; }
        public long NewFloorTypeId { get; set; }
        public Boolean IsMovingHeavyObject { get; set; }
        public Boolean IsMovingValueableItem { get; set; }
        public String AdditionalInfo { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public string ContactPerson { get; set; }
        public long WhichFloorTypeId { get; set; }
        public bool Islift { get; set; }
        public bool IsNewlift { get; set; }
        public long NewWhichFloorTypeId { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value1 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value2 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value3 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value4 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value5 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value6 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value7 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value8 { get; set; }

    }
}
