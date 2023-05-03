using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class BannerDetail : CommonDbProp
    {
        public long ContentManagmentId { get; set; }
        public string BannerImageUrl { get; set; }
        public string BannerTitle { get; set; }
        public string BannerDescription { get; set; }
        public ContentManagment ContentManagment { get; set; }
    }
}
