using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class sys_drop_down_mf:CommonDbProp
    {
        public sys_drop_down_mf()
        {
            this.sys_drop_down_value = new List<sys_drop_down_value>();
        }
        public string Name { get; set; }
        public virtual ICollection<sys_drop_down_value> sys_drop_down_value { get; set; }
    }
}
