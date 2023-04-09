using DTO.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace DTO.Models
{
    public class Account : CommonDbProp
    {
        public Account()
        {
            Category = new HashSet<Category>();
            Makes = new HashSet<Makes>();
            Vehicle = new HashSet<Vehicle>();
            VehicleModels = new HashSet<VehicleModels>();
            AuthTokens = new HashSet<AuthToken>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        public string PhoneNumber { get; set; }
        public string Address { get; set; }  
        public bool IsEmailVerified { get; set; }
        public bool IsVerifiedAccount { get; set; }
        public string ProfileImage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public AccountType AccountType { get; set; }
        public GanderTypeEnum GanderType { get; set; }
        public AccountStatusEnum AccountStatus { get; set; }
        public virtual ICollection<Makes> Makes { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
        public virtual ICollection<VehicleModels> VehicleModels { get; set; }
        public virtual ICollection<AuthToken> AuthTokens { get; set; }
    }
}
