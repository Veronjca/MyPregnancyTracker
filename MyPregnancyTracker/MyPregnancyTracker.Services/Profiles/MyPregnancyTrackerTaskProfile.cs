using AutoMapper;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.TasksModels;

namespace MyPregnancyTracker.Services.Profiles
{
    public class MyPregnancyTrackerTaskProfile : Profile
    {
        public MyPregnancyTrackerTaskProfile()
        {
            CreateMap<MyPregnancyTrackerTask, TaskDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }
    }
}
