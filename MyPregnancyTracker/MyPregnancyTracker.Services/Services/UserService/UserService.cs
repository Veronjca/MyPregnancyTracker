using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models.AccountsModels;
using MyPregnancyTracker.Services.Services.TasksService;
using SendGrid.Helpers.Errors.Model;

namespace MyPregnancyTracker.Services.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IRepository<ApplicationUserMyPregnancyTrackerTask> _userTasksRepository;
        private readonly ITasksService _tasksService;
        private readonly IDataProtector _dataProtector;

        public UserService(IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUser> userRepository,
            IRepository<ApplicationUserMyPregnancyTrackerTask> userTasksRepository,
            ITasksService tasksService)
        {
            this._configuration = configuration;
            this._userManager = userManager;
            this._userRepository = userRepository;
            this._userTasksRepository = userTasksRepository;
            this._tasksService = tasksService;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }

        public async Task SetDueDateAsync(ApplicationUser user, DateTime firstDayOfLastMenstruation)
        {
            //Pregnancy duration is 10 months x 28 days.
            var dueDate = firstDayOfLastMenstruation.AddDays(280);
            user.DueDate = dueDate;

            this._userRepository.Update(user);
            await this._userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserProfileDataAsync(UpdateUserProfileRequest updateUserProfileRequest)
        {
            var userId = this._dataProtector.Unprotect(updateUserProfileRequest.UserId);
            var user = await this._userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new NotFoundException();
            }

            user.FirstName = updateUserProfileRequest.FirstName;
            user.LastName = updateUserProfileRequest.LastName;
            user.BirthDate = updateUserProfileRequest.BirthDate;
            user.Weight = updateUserProfileRequest.Weight;
            user.Height = updateUserProfileRequest.Height;

            if (updateUserProfileRequest.DueDate.HasValue)
            {
                user.DueDate = updateUserProfileRequest.DueDate.Value;
            }

            this._userRepository.Update(user);
            await this._userRepository.SaveChangesAsync();
        }

        public async Task<GetUserProfileDataResponse> GetUserProfileDataAsync(string userId)
        {
            userId = this._dataProtector.Unprotect(userId);
            var user = await this._userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new NotFoundException();
            }

            var response = new GetUserProfileDataResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate.HasValue ? user.BirthDate.Value.ToLocalTime() : null,
                Height = user.Height,
                Weight = user.Weight,
                DueDate = user.DueDate.ToLocalTime(),
            };

            return response;
        }

        public async Task SetGestationalWeekAsync(ApplicationUser user, DateTime firstDayOfLastMenstruation)
        {
            var currentDate = DateTime.UtcNow.ToLocalTime();
            var gestationalAge = (int)(currentDate - firstDayOfLastMenstruation).TotalDays / 7;

            if(gestationalAge > 42)
            {
                gestationalAge = 42;
            }
            else if(gestationalAge < 1)
            {
                gestationalAge = 1;
            }

            if (user.GestationalWeekAge != gestationalAge)
            {
                user.GestationalWeekAge = gestationalAge;
            }

            this._userRepository.Update(user);
            await this._userRepository.SaveChangesAsync();
        }

        public async Task AddTaskAsync(string userId, string taskId)
        {
            var task = await this._tasksService.GetOneTaskAsync(taskId);
            userId = this._dataProtector.Unprotect(userId);
            var user = await this._userManager.FindByIdAsync(userId);

            if(user == null)
            {
                throw new NotFoundException();
            }

            var applicationUserMyPregnancyTrackerTask = new ApplicationUserMyPregnancyTrackerTask
            {
                ApplicationUserId = int.Parse(userId),
                MyPregnancyTrackerTaskId = task.Id
            };

            user.ApplicationUsersMyPregnancyTrackerTasks.Add(applicationUserMyPregnancyTrackerTask);

            this._userRepository.Update(user);
            await this._userRepository.SaveChangesAsync();
        }

        public async Task RemoveTaskAsync(string userId, string taskId)
        {
            var unprotectedTaskId = int.Parse(this._dataProtector.Unprotect(taskId));  
            var unprotectedUserId = int.Parse(this._dataProtector.Unprotect(userId));

            var userTask = await this._userTasksRepository
                .GetAll()
                .Where(x => x.MyPregnancyTrackerTaskId == unprotectedTaskId && x.ApplicationUserId == unprotectedUserId)
                .FirstAsync();

            this._userTasksRepository.Delete(userTask);   
            await this._userTasksRepository.SaveChangesAsync();
        }
    }
}
