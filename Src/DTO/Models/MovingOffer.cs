using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class MovingOffer : CommonDbProp
    {

        public Boolean IsPacking { get; set; }
        public String MovingDate { get; set; }
        public Boolean IsWarehousehotel { get; set; }
        public Boolean Ispiano { get; set; }
        public String CurrentAddress { get; set; }
        public String StreetNo { get; set; }
        public String PostalCode { get; set; }
        public String SizeOfHome { get; set; }
        public long TotalRoomId { get; set; }
        public long HouseTypeId { get; set; }
        public long FloorTypeId { get; set; }
        public String garage { get; set; }
        public String ParkingDistance { get; set; }
        public String NewAddress { get; set; }
        public String NewStreetNo { get; set; }
        public String NewPostalCode { get; set; }
        public long NewTotalRoomId { get; set; }
        public long NewHouseTypeId { get; set; }
        public String NewSizeOfHome { get; set; }
        public long NewFloorTypeId { get; set; }
        public String NewParkingDistance { get; set; }
        public String Newgarage { get; set; }

        public String AdditionalInfo { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }


        public virtual sys_drop_down_value sys_drop_down_value { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value1 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value2 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value3 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value4 { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value5 { get; set; }

    }
}
