using DTO.ViewModel.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel.ContentManagment
{
    public class ContentManagmentResponse
    {
        public long ID { get; set; }
        public long ContentTypeId { get; set; }
        public string Name { get; set; }
        public string ContentDescription { get; set; }
        public Boolean IsActive { get; set; }
        public virtual ICollection<BannerList> BannerList { get; set; }
    }
}
