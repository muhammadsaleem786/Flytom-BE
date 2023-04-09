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
        public DateTime MovingDate { get; set; }
        public Boolean IsFlexible { get; set; }
        public DateTime DesiredMovingDate { get; set; }
        public Boolean IsPackedItem { get; set; }
        public Boolean IsStoreObject { get; set; }
        public Boolean IsCurrentHome { get; set; }
        public Boolean IsInsureMoving { get; set; }
        public string MovingLoad { get; set; }
        public string NoOfPeople { get; set; }
        public String CurrentAddress { get; set; }
        public String StreetNo { get; set; }
        public String SizeOfHome { get; set; }
        public String TotalRoom { get; set; }
        public String HouseType { get; set; }
        public Boolean IsMovedStorageRoom { get; set; }
        public Boolean IsMovedGarage { get; set; }
        public string ParkingDistance { get; set; }
        public String NewAddress { get; set; }
        public String NewStreetNo { get; set; }
        public String PostalCode { get; set; }
        public String NewTotalRoom { get; set; }
        public string NewHouseType { get; set; }
        public string ApartmentFloor { get; set; }
        public Boolean IsLift { get; set; }
        public string NewParkingDistance { get; set; }
        public Boolean IsMovingHeavyObject { get; set; }
        public Boolean IsMovingValueableItem { get; set; }
        public string AdditionalInfo { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
    }
}
