using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class Contact:CommonDbProp
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public long EnquiryTypeId { get; set; }
    }
}
