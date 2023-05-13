using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Delivery:CommonDbProp
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String MoveingDate { get; set; }
        public String Address { get; set; }
        public String PostalCode { get; set; }
        public String ArealBRA { get; set; }
        public long HousingTypeId { get; set; }
        public String VolumeCBMM3 { get; set; }
        public String FloorTypeId{ get; set; }
    }
}
