using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Models.TasksModels;
using MyPregnancyTracker.Services.Services.TasksService;
using MyPregnancyTracker.Services.Services.UserService;
using SendGrid.Helpers.Errors.Model;
using static MyPregnancyTracker.Web.Constants.Constants.TasksControllerRoutes;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(TASKS_ROUTE)]
    public class TasksController : BaseController
    {
        private readonly ITasksService _taskService;

        public TasksController(ITasksService taskService)
        {
            this._taskService = taskService;
        }

        [HttpGet]
        [Route(GET_USER_TASKS_ROUTE)]
        public async Task<IActionResult> GetUserTasksAsync([FromQuery] string userId)
        {
            try
            {
                var tasks = await this._taskService.GetUserTasksAsync(userId);
                return StatusCode(200, tasks);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }
    }
}
