using Microsoft.AspNetCore.Mvc;
using static MyPregnancyTracker.Web.Constants.Constants.TasksControllerRoutes;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(TASKS_ROUTE)]
    public class TasksController : BaseController
    {
        public TasksController()
        {

        }

        [HttpGet]
        [Route(GET_USER_TASKS_ROUTE)]
        public async Task<IActionResult> GetUserTasks([FromQuery] string userId)
        {
            throw new NotImplementedException();
        }
    }
}
