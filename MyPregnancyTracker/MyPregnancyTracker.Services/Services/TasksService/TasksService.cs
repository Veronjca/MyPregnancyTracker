using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models.TasksModels;
using SendGrid.Helpers.Errors.Model;

namespace MyPregnancyTracker.Services.Services.TasksService
{
    public class TasksService : ITasksService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IRepository<MyPregnancyTrackerTask> _tasksRepository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _dataProtector;

        public TasksService(UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            IRepository<ApplicationUser> userRepository,
            IRepository<MyPregnancyTrackerTask> tasksRepository,
            IMapper mapper)
        {
            this._userManager = userManager;
            this._configuration = configuration;
            this._userRepository = userRepository;
            this._tasksRepository = tasksRepository;
            this._mapper = mapper;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }
        public async Task<List<GetUserTasksResponseDto>> GetUserTasksAsync(string userId)
        {
            userId = this._dataProtector.Unprotect(userId);
            var user = await this._userManager.FindByIdAsync(userId);

            if(user == null)
            {
                throw new BadRequestException();
            }

            var tasksIds = user.ApplicationUsersMyPregnancyTrackerTasks.Select(x => x.MyPregnancyTrackerTaskId).ToList();

            var tasks = await this._tasksRepository.GetAll().Where(x => tasksIds.Contains(x.Id)).ToListAsync();
            var mappedTasks = this._mapper.Map<List<GetUserTasksResponseDto>>(tasks);

            foreach (var task in mappedTasks)
            {
                task.Id = this._dataProtector.Protect(task.Id);
            };

            return mappedTasks;
        }
    }
}
