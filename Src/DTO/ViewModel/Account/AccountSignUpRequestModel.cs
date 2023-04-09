using DTO.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace DTO.ViewModel.Account
{
    public class AccountSignUpRequestModel
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
