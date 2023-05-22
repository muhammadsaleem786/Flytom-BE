using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Contact : CommonDbProp
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string ContactType { get; set; } = "P";
        public long EnquiryTypeId { get; set; }
    public virtual sys_drop_down_value sys_drop_down_value { get; set; }

}
}
