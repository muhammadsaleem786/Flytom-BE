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
        public String DesiredMovingDate { get; set; }
        public String FlexibleMovingDateId { get; set; }
        public String IsFlexible { get; set; }
        public String IsPackedItem { get; set; }
        public String IsStoreObject { get; set; }
        public String IsCurrentHome { get; set; }
        public String IsInsureMoving { get; set; }
        public String MovingLoadId { get; set; }
        public String NoOfPeopleId { get; set; }
        public String CurrentAddress { get; set; }
        public String StreetNo { get; set; }
        public String SizeOfHome { get; set; }
        public String PostalCode { get; set; }
        public String TotalRoomId { get; set; }
        public String HouseTypeId { get; set; }
        public String IsMovedStorageRoom { get; set; }
        public String IsMovedGarage { get; set; }
        public String ParkingDistance { get; set; }
        public String FloorTypeId { get; set; }
        public String NewAddress { get; set; }
        public String NewStreetNo { get; set; }
        public String NewPostalCode { get; set; }
        public String NewTotalRoomId { get; set; }
        public String NewHouseTypeId { get; set; }
        public String NewSizeOfHome { get; set; }
        public String NewParkingDistance { get; set; }
        public String NewFloorTypeId { get; set; }
        public String IsMovingHeavyObject { get; set; }
        public String IsMovingValueableItem { get; set; }
        public String AdditionalInfo { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public string ContactPerson { get; set; }
        public String EmployeeId { get; set; }
        public String WhichFloorTypeId { get; set; }
        public String Islift { get; set; }
        public String IsNewlift { get; set; }
        public String NewWhichFloorTypeId { get; set; }
        public string CompanyFloorTypeId { get; set; }
    }
}
