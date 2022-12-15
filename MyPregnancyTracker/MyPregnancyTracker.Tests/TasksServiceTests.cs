using Microsoft.EntityFrameworkCore;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Services.TasksService;

namespace MyPregnancyTracker.Tests
{
    public class TasksServiceTests : SetUp
    {
        private ITasksService _tasksService;

        [SetUp]
        public async Task SetUp()
        {
            await InitializeDatabase();

            var userManager = GetUserManager();
            var configuration = GetIConfiguration();
            var dataProtector = GetProtectionProvider();
            var userRepository = GetUserRepository();
            var tasksRepository = GetTaskRepository();
            var userTasksRepository = GetUsersTasksRepository();
            var mapper = GetMapper();

            this._tasksService = new TasksService(userManager, configuration, dataProtector, userRepository, tasksRepository, userTasksRepository, mapper);
        }

        [Test]
        public async Task GetAllShouldWorkProperly()
        {
            int gestationalAge = 1;
            string userId = MOCK_USER_ID;

            var expectedTaskCount = context.Set<MyPregnancyTrackerTask>()
                .Include(t => t.GestationalWeek)
                .Where(t => t.GestationalWeek.GestationalAge == gestationalAge)
                .Count();

            var result = await this._tasksService.GetAllTasksAsync(gestationalAge, userId);

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(expectedTaskCount));
        }

        [Test]
        public async Task GetOneShouldWorkProperly()
        {
            var taskId = MOCK_PROTECTED_TASK_ID;

            var task = context.Set<MyPregnancyTrackerTask>()
                .FirstOrDefault(t => t.Id == 1);

            var result = await this._tasksService.GetOneTaskAsync(taskId);

            Assert.IsNotNull(result);
            Assert.That(task.Content, Is.EqualTo(result.Content));
        }
    }
}
