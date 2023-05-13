using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel.Offer
{
    public class OfferRequest
    {
        public long Id { get; set; }
        public String IsPacking { get; set; }
        public String MovingDate { get; set; }
        public String IsWarehousehotel { get; set; }
        public String Ispiano { get; set; }
        public String CurrentAddress { get; set; }
        public String StreetNo { get; set; }
        public String PostalCode { get; set; }
        public String SizeOfHome { get; set; }
        public String TotalRoomId { get; set; }
        public String HouseTypeId { get; set; }
        public String FloorTypeId { get; set; }
        public String garage { get; set; }
        public String ParkingDistance { get; set; }
        public String NewAddress { get; set; }
        public String NewStreetNo { get; set; }
        public String NewPostalCode { get; set; }
        public String NewTotalRoomId { get; set; }
        public String NewHouseTypeId { get; set; }
        public String NewSizeOfHome { get; set; }
        public String NewFloorTypeId { get; set; }
        public String NewParkingDistance { get; set; }
        public String Newgarage { get; set; }

        public String AdditionalInfo { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
    }
}
