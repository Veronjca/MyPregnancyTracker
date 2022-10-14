using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Models;
using static MyPregnancyTracker.Web.Constants.Constants.Route;
using MyPregnancyTracker.Services.Services.AccountService;
using MyPregnancyTracker.Services.Services.EmailService;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(ACCOUNTS_ROUTE)]
    [ApiController]
    public class AccountsController : Controller
    {
        //Register
        //RefreshAccessToken
        //ConfrimEmail
        //ResendConfirmationEmail
        //ResetPassword
        //Logout

        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;
        public AccountsController(
            IAccountService accountService,
            IEmailService emailService)
        {
            _accountService = accountService;
            _emailService = emailService;   
        }

        [HttpPost]
        [Route(LOGIN_ROUTE)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = new LoginResponseDto();

            try
            {
                result = await _accountService.SignInUserAsync(loginDto);
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

        [HttpPost]
        [Route(REGISTER_ROUTE)]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await _accountService.SignUpUserAsync(registerDto);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var user = await _accountService.GetUserByEmailAsync(registerDto.Email);
            var token = await _accountService.GenerateEmailConfirmationTokenAsync(user);

            await _emailService.SendConfirmationEmailAsync(user, token);

            return StatusCode(201);
        }
    }
}
