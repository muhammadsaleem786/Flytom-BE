using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel.Account
{
    public class GetAccountResponse
    {
        public string ProfileImage { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public bool? IsStacked { get; set; }
    }
}
