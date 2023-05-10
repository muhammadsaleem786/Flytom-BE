using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class sys_drop_down_value:CommonDbProp
    {
        public sys_drop_down_value()
        {
            Vehicle = new HashSet<Vehicle>();
            Vehicle1 = new HashSet<Vehicle>();
            Vehicle2 = new HashSet<Vehicle>();
            Vehicle3 = new HashSet<Vehicle>();
            Vehicle4 = new HashSet<Vehicle>();
            Vehicle5 = new HashSet<Vehicle>();
            VehiclePart= new HashSet<VehiclePart>();
            Offer = new HashSet<Offer>();
            Offer1 = new HashSet<Offer>();
            Offer2 = new HashSet<Offer>();
            Offer3 = new HashSet<Offer>();
            Offer4 = new HashSet<Offer>();
            Offer5 = new HashSet<Offer>();
            Offer6 = new HashSet<Offer>();
            Offer7 = new HashSet<Offer>();
            Offer8 = new HashSet<Offer>();

            ContentManagment = new HashSet<ContentManagment>();
        }

        public long DropDownID { get; set; }
        public string Value { get; set; }
        public string ValueInNorwegian { get; set; }
        public Nullable<int> DependedDropDownID { get; set; }
        public Nullable<int> DependedDropDownValueID { get; set; }
        public Nullable<bool> SystemGenerated { get; set; }
        public Nullable<decimal> CompanyID { get; set; }
        public virtual sys_drop_down_mf sys_drop_down_mf { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<Vehicle> Vehicle1 { get; set; }
        public virtual ICollection<Vehicle> Vehicle2 { get; set; }
        public virtual ICollection<Vehicle> Vehicle3 { get; set; }
        public virtual ICollection<Vehicle> Vehicle4 { get; set; }
        public virtual ICollection<Vehicle> Vehicle5 { get; set; }
        public virtual ICollection<VehiclePart> VehiclePart { get; set; }

        public virtual ICollection<Offer> Offer { get; set; }
        public virtual ICollection<Offer> Offer1 { get; set; }
        public virtual ICollection<Offer> Offer2 { get; set; }
        public virtual ICollection<Offer> Offer3{ get; set; }
        public virtual ICollection<Offer> Offer4 { get; set; }
        public virtual ICollection<Offer> Offer5 { get; set; }
        public virtual ICollection<Offer> Offer6 { get; set; }
        public virtual ICollection<Offer> Offer7 { get; set; }
        public virtual ICollection<Offer> Offer8 { get; set; }
        public virtual ICollection<ContentManagment> ContentManagment { get; set; }
    }
}
