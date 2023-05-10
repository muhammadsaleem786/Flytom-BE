using DTO.ViewModel.Account;
using System;

namespace DTO.ViewModel.Token
{
    public class AuthModel
    {
        public string Token { get; set; }
        public DateTime? ValidTo { get; set; }
        public string Email { get; set; }
        public AccountViewModel UserInfo { get; set; }
    }
}
