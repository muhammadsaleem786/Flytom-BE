using DTO.Enums;
using System;

namespace DTO.ViewModel.Account
{
    public class AccountViewModel
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string AccountType { get; set; }
        public string ProfileImage { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string ContractAddress { get; set; }

    }
}
