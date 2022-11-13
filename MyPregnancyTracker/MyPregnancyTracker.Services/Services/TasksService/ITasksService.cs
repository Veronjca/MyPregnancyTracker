using MyPregnancyTracker.Services.Models.TasksModels;

namespace MyPregnancyTracker.Services.Services.TasksService
{
    public interface ITasksService
    {
        /// <summary>
        /// Get user tasks, as asynchronous operation.
        /// </summary>
        /// <param name="userId">The user's id.</param>
        Task<List<GetUserTasksResponseDto>> GetUserTasksAsync(string userId);
    }
}
