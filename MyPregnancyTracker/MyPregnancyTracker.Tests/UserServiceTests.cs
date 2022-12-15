using Microsoft.AspNetCore.DataProtection;
using Moq;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models.AccountsModels;
using MyPregnancyTracker.Services.Services.TasksService;
using MyPregnancyTracker.Services.Services.UserService;
using System.Text;

namespace MyPregnancyTracker.Tests
{
    public class UserServiceTests : SetUp
    {
        private ITasksService _taskService; 
        private IUserService _userService;
        private IRepository<ApplicationUserMyPregnancyTrackerTask> _usersTasksRepository;

        [SetUp]
        public async Task SetUp()
        {
            await InitializeDatabase();

            var configuration = GetIConfiguration();
            var dataProtector = GetProtectionProvider();
            var userManager = GetUserManager();
            var userRepository = GetUserRepository();
            this._usersTasksRepository = GetUsersTasksRepository();
            var tasksRepository = GetTaskRepository();
            var mapper = GetMapper();

            this._taskService = new TasksService(userManager, configuration, dataProtector, userRepository, tasksRepository, this._usersTasksRepository, mapper);
            this._userService = new UserService(configuration, dataProtector, userManager, userRepository, this._usersTasksRepository, this._taskService);
        }

        [Test]
        public async Task SetDueDateShouldWorkProperly()
        {
            var firstDayOfLastMenstruation = new DateTime(2022, 9, 1);
            var expectedDueDate = new DateTime(2023, 6, 8);

            var user = context.Set<ApplicationUser>()
                .FirstOrDefault();

            await this._userService.SetDueDateAsync(user, firstDayOfLastMenstruation);

            var actualDueDate = context.Set<ApplicationUser>()
                .FirstOrDefault()
                .DueDate;
           
            Assert.That(actualDueDate, Is.EqualTo(expectedDueDate));
        }

        [Test]
        public async Task UpdateUserProfileShouldWorkProperly()
        {
            var updateUserProfileRequest = new UpdateUserProfileRequest
            {
                BirthDate = new DateTime(2022,9,22),
                FirstName = "Veronica",
                UserId = MOCK_USER_ID
            };

            await this._userService.UpdateUserProfileDataAsync(updateUserProfileRequest);

            var user = context.Set<ApplicationUser>()
                .FirstOrDefault(u => u.Id == 1);

            Assert.That(user.BirthDate, Is.EqualTo(updateUserProfileRequest.BirthDate));
            Assert.That(user.FirstName
                , Is.EqualTo(updateUserProfileRequest.FirstName));
        }

        [Test]
        public async Task GetUserProfileDataShouldWorkProperly()
        {
            string userId = MOCK_USER_ID;

            var result = await this._userService.GetUserProfileDataAsync(userId);

            var user = context.Set<ApplicationUser>()
                .FirstOrDefault(u => u.Id == 1);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.DueDate);
            Assert.That(result.DueDate, Is.EqualTo(user.DueDate.ToLocalTime()));
        }

        [Test]
        public async Task SetGestationalWeekShouldWorkProperly()
        {
            var firstDayOfLastMenstruation = new DateTime(2022, 9, 1);
            var user = context.Set<ApplicationUser>()
                .First();

            var currentDate = DateTime.UtcNow.ToLocalTime();
            var expectedGestationalWeekAge = (int)(currentDate - firstDayOfLastMenstruation).TotalDays / 7;
          
            await this._userService.SetGestationalWeekAsync(user, firstDayOfLastMenstruation);  

            Assert.That(user.GestationalWeekAge, Is.EqualTo((int)expectedGestationalWeekAge));  
        }

        [Test]
        public async Task AddTaskShouldWorkProperly()
        {
            var mockedDataProtector = new Mock<IDataProtector>();
            mockedDataProtector.Setup(x => x.Protect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes("protected value"));
            mockedDataProtector.Setup(x => x.Unprotect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes("2"));

            var mockedProvider = new Mock<IDataProtectionProvider>();
            mockedProvider.Setup(x => x.CreateProtector(It.IsAny<string>())).Returns(mockedDataProtector.Object);

            var configuration = GetIConfiguration();
            var userManager = GetUserManager();
            var userRepository = GetUserRepository();
            var tasksRepository = GetTaskRepository();
            var mapper = GetMapper();


            this._taskService = new TasksService(userManager, configuration, mockedProvider.Object, userRepository, tasksRepository, this._usersTasksRepository, mapper);

            this._userService = new UserService(configuration, mockedProvider.Object, userManager, userRepository, this._usersTasksRepository, this._taskService);

            var userId = MOCK_USER_ID;
            var taskId = MOCK_PROTECTED_TASK_ID;
            var expectedCount = 3;

            await this._userService.AddTaskAsync(userId, taskId);

            var actualCount = context.Set<ApplicationUserMyPregnancyTrackerTask>().Count();

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public async Task RemoveTaskShouldWorkProperly()
        {
            var userId = MOCK_USER_ID;
            var taskId = MOCK_PROTECTED_TASK_ID;
            var expectedCount = 1;

            await this._userService.RemoveTaskAsync(userId, taskId);

            var actualCount = context.Set<ApplicationUserMyPregnancyTrackerTask>().Count();

            Assert.AreEqual(expectedCount, actualCount);   
        }

    }
}
