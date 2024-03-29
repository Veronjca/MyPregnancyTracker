﻿using AutoMapper;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.AccountsModels;

namespace MyPregnancyTracker.Services.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, LoginResponseDto>();
            CreateMap<RegisterDto, ApplicationUser>();
        }
    }
}
