using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.AccountsModels;
using MyPregnancyTracker.Services.Services.UserService;
using SendGrid.Helpers.Errors.Model;
using static MyPregnancyTracker.Web.Constants.Constants.UserControllerRoutes;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(USER_ROUTE)]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDataProtector _dataProtector;

        public UserController(IUserService userService,
            IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            UserManager<ApplicationUser> userManager)
        {
            this._userService = userService;
            this._configuration = configuration;
            this._userManager = userManager;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }

        [HttpPost]
        [Route(UPDATE_USER_PROFILE_ROUTE)]
        public async Task<IActionResult> UpdateUserProfileDataAsync([FromBody] UpdateUserProfileRequest updateUserProfileRequest)
        {
            try
            {
                await this._userService.UpdateUserProfileDataAsync(updateUserProfileRequest);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [Route(GET_USER_PROFILE_DATA_ROUTE)]
        public async Task<IActionResult> GetUserProfileDataAsync([FromQuery] string userId)
        {
            userId = this._dataProtector.Unprotect(userId);

            try
            {
                var response = await this._userService.GetUserProfileDataAsync(userId);
                return StatusCode(200, response);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route(ADD_TASK_ROUTE)]
        public async Task<IActionResult> AddTaskAsync([FromQuery] string userId, [FromQuery] string taskId)
        {
            await this._userService.AddTaskAsync(userId, taskId);

            return Ok();
        }

        [HttpPost]
        [Route(REMOVE_TASK_ROUTE)]
        public async Task<IActionResult> RemoveTaskAsync([FromQuery] string userId, [FromQuery] string taskId)
        {
            await this._userService.RemoveTaskAsync(userId, taskId);

            return Ok();
        }

        [HttpGet]
        [Route(SET_GESTATIONAL_WEEK_ROUTE)]
        public async Task<IActionResult> SetGestationalWeekAsync([FromQuery] string userId)
        {
            var id = this._dataProtector.Unprotect(userId);
            var user = await this._userManager.FindByIdAsync(id);

            await this._userService.SetGestationalWeekAsync(user, user.FirstDayOfLastMenstruation);

            return Ok();
        }
    }
}

