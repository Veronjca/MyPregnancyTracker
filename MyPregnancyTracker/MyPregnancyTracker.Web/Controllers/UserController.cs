using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IDataProtector _dataProtector;

        public UserController(IUserService userService,
            IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider)
        {
            this._userService = userService;
            this._configuration = configuration;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }

        [HttpPost]
        [Route(UPDATE_USER_PROFILE_ROUTE)]
        public async Task<IActionResult> UpdateUserProfileData([FromBody] UpdateUserProfileRequest updateUserProfileRequest)
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
        public async Task<IActionResult> GetUserProfileData([FromQuery] string userId)
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
    }
}

