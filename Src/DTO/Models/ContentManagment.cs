using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class ContentManagment : CommonDbProp
    {
        public long ContentTypeId { get; set; }
        public string ContentDescription { get; set; }
        public Boolean IsActive { get; set; }
        public virtual sys_drop_down_value sys_drop_down_value { get; set; }
        public virtual ICollection<BannerDetail> BannerDetail { get; set; }
    }

}
