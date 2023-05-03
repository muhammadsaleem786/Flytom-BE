using DTO.ViewModel.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel.ContentManagment
{
    public class ContentManagmentRequest
    {
        public long ID { get; set; }
        public string ContentTypeId { get; set; }
        public string ContentDescription { get; set; }
        public Boolean IsActive { get; set; }
        public virtual ICollection<BannerList> BannerList { get; set; }
    }
    public class BannerList
    {
        public long ID { get; set; }
        public string BannerImageUrl { get; set; }
        public string BannerTitle { get; set; }
        public string BannerDescription { get; set; }
    }
}
