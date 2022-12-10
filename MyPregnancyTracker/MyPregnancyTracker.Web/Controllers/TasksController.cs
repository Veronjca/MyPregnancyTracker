using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Services.TasksService;
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
        [Route(GET_ALL_TASKS_ROUTE)]
        public async Task<IActionResult> GetAllTasksAsync([FromQuery] int gestationalAge, [FromQuery] string userId)
        {
            try
            {
                var tasks = await this._taskService.GetAllTasksAsync(gestationalAge, userId);
                return StatusCode(200, tasks);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
