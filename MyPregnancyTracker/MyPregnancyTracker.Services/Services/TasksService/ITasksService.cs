using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.TasksModels;

namespace MyPregnancyTracker.Services.Services.TasksService
{
    public interface ITasksService
    {
        /// <summary>
        /// Gets all tasks for the specified gestational week, as asynchronous operation.
        /// </summary>
        /// <param name="gestationalAge">Gestational week's gestational age.</param>
        /// <param name="userID">The user's id used to get user's tasks.</param>
        Task<List<TaskDto>> GetAllTasksAsync(int gestationalAge, string userId);

        /// <summary>
        /// Gets specified task, as asynchronous operation.
        /// </summary>
        /// <param name="taskId">The protected task id.</param>
        Task<MyPregnancyTrackerTask> GetOneTaskAsync(string taskId);
    }
}
