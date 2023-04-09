using DTO.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel.Account
{
    public class UpdateAccountRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public IFormFile ProfileImage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public GanderTypeEnum GanderType { get; set; }

    }
}
