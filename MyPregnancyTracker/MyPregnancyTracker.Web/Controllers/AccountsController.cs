using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Models;
using static MyPregnancyTracker.Web.Constants.Constants.Route;
using static MyPregnancyTracker.Web.Constants.Constants.Error;
using MyPregnancyTracker.Services.Services.AccountService;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(ACCOUNTS_ROUTE)]
    [ApiController]
    public class AccountsController : Controller
    {
        //Login
        //Register
        //RefreshAccessToken
        //ConfrimEmail
        //ResendConfirmationEmail
        //ResetPassword

        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route(LOGIN_ROUTE)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(INVALID_LOGIN);
            }

            var result = new LoginResponseDto();

            try
            {
                result = await _accountService.SignInUser(loginDto);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch(Exception ex)
            {
                if(ex is InvalidOperationException || ex is MemberAccessException)
                {
                    return Unauthorized(ex.Message);
                }
            }

            return Ok(result);
        }
    }
}
