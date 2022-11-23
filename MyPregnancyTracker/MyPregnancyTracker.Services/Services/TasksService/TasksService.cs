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
        private readonly IRepository<ApplicationUserMyPregnancyTrackerTask> _userTasks;
        private readonly IMapper _mapper;
        private readonly IDataProtector _dataProtector;

        public TasksService(UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            IRepository<ApplicationUser> userRepository,
            IRepository<MyPregnancyTrackerTask> tasksRepository,
            IRepository<ApplicationUserMyPregnancyTrackerTask> userTasksRepository,
            IMapper mapper)
        {
            this._userManager = userManager;
            this._configuration = configuration;
            this._userRepository = userRepository;
            this._tasksRepository = tasksRepository;
            this._userTasks = userTasksRepository;
            this._mapper = mapper;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }

        public async Task<List<TaskDto>> GetAllTasksAsync(int gestationalAge, string userId)
        {
            try
            {
                var userTasksIds = await this.GetUserTasksIdsAsync(userId);

                var tasks = this._tasksRepository
               .GetAll()
               .Include(t => t.GestationalWeek)
               .Where(t => t.GestationalWeek.GestationalAge == gestationalAge)
               .ToList()
               .Select(t => new TaskDto
               {
                   Id = this._dataProtector.Protect(t.Id.ToString()),
                   Content = t.Content,
                   Selected = userTasksIds.Contains(t.Id) ? true : false,
               })
               .ToList();

                return tasks;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }       
        }

        public async Task<MyPregnancyTrackerTask> GetOneTaskAsync(string taskId)
        {
            int id = int.Parse(this._dataProtector.Unprotect(taskId));

            return await this._tasksRepository.GetAll().Where(t => t.Id == id).FirstAsync();
        }

        private async Task<List<int>> GetUserTasksIdsAsync(string userId)
        {
            userId = this._dataProtector.Unprotect(userId);
            var user = await this._userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new NotFoundException();
            }

            var tasksIds = await this._userTasks
                .GetAll()
                .Where(x => x.ApplicationUserId == user.Id)
                .Select(x => x.MyPregnancyTrackerTaskId)
                .ToListAsync();

            return tasksIds;
        }
    }
}
