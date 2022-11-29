using AutoMapper;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.AccountsModels;
using MyPregnancyTracker.Services.Models.TasksModels;
using MyPregnancyTracker.Services.Models.TopicsModels;

namespace MyPregnancyTracker.Services.Profiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, LoginResponseDto>();
            CreateMap<RegisterDto, ApplicationUser>();
            CreateMap<MyPregnancyTrackerTask, TaskDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
