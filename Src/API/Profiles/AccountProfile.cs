using AutoMapper;
using DTO.Models;
using DTO.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountViewModel>().ReverseMap();
            CreateMap<Account, AccountViewModel>();


        }
    }
}
