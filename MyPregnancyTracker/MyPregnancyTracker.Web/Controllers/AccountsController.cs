using Microsoft.AspNetCore.Mvc;
using static MyPregnancyTracker.Web.Constants.Constants.AccountsControllerRoutes;
using MyPregnancyTracker.Services.Services.AccountService;
using MyPregnancyTracker.Services.Services.EmailService;
using SendGrid.Helpers.Errors.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using MyPregnancyTracker.Services.Models.AccountsModels;
using MyPregnancyTracker.Services.Services.UserService;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(ACCOUNTS_ROUTE)]
    public class AccountsController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;
        private readonly IDataProtector _dataProtector;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AccountsController(
            IAccountService accountService,
            IEmailService emailService,
            IDataProtectionProvider dataProtectionProvider,
            IConfiguration configuration,
            IUserService userService)
        {
            this._accountService = accountService;
            this._emailService = emailService;
            this._configuration = configuration;
            this._userService = userService;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }

        [HttpPost]
        [Route(LOGIN_ROUTE)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _accountService.SignInUserAsync(loginDto);

                return Ok(result);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch(BadRequestException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route(REGISTER_ROUTE)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            var result = await _accountService.SignUpUserAsync(registerDto);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var user = await _accountService.GetUserByEmailAsync(registerDto.Email);
            var token = await _accountService.GenerateEmailConfirmationTokenAsync(user);

            await _emailService.SendConfirmationEmailAsync(user, token);
            var protectedEmail = this._dataProtector.Protect(user.Email);

            try
            {
                await this._userService.SetDueDateAsync(user, registerDto.FirstDayOfLastMenstruation);
                await this._userService.SetGestationalWeekAsync(user, registerDto.FirstDayOfLastMenstruation);
            }
            catch (BadRequestException)
            {
                return BadRequest();
            }

            var response = new RegisterResponseDto
            {
                ProtectedEmail = protectedEmail
            };

            return StatusCode(201, response);
        }

        [HttpPost]
        [Route(CONFIRM_EMAIL_ROUTE)]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmailAsync([FromBody] ConfirmEmailDto confirmEmailDto)
        {

            try
            {
                var isEmailConfirmed = await _accountService.ConfirmEmailAsync(confirmEmailDto.EmailToken, confirmEmailDto.UserId);

                if (!isEmailConfirmed.Succeeded)
                {
                    return BadRequest(isEmailConfirmed.Errors);
                }

                return Ok();
            }
            catch (NotFoundException)
            {

                return NotFound();
            }
        }

        [HttpPost]
        [Route(RESEND_CONFIRMATION_EMAIL_ROUTE)]
        [AllowAnonymous]
        public async Task<IActionResult> ResendConfirmationEmailAsync([FromBody] ResendConfirmationEmailDto resendConfirmationEmailDto)
        {
            var email = this._dataProtector.Unprotect(resendConfirmationEmailDto.Email);

            var user = await _accountService.GetUserByEmailAsync(email);
            var token = await _accountService.GenerateEmailConfirmationTokenAsync(user);

            await _emailService.SendConfirmationEmailAsync(user, token);

            return Ok();
        }

        [HttpPost]
        [Route(RESET_PASSWORD_ROUTE)]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordDto resetPasswordDto)
        {
            try
            {
                var result = await _accountService.ResetPasswordAsync(resetPasswordDto);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (NotFoundException)
            {

                return NotFound();
            }               

            return Ok();
        }

        [HttpPost]
        [Route(REFRESH_ACCESS_TOKEN_ROUTE)]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshAccessTokenAsync([FromBody] RefreshAccessTokenDto refreshAccessTokenDto)
        {
            try
            {
                var response = await _accountService.RefreshAccessTokenAsync(refreshAccessTokenDto);

                return Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Forbid(ex.Message);
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route(SEND_RESET_PASSWORD_EMAIL_ROUTE)]
        [AllowAnonymous]
        public async Task<IActionResult> SendResetPasswordEmailAsync([FromBody] ResetPasswordEmailDto resetPasswordEmailDto)
        {
            try
            {
                await _accountService.SendResetPasswordEmailAsync(resetPasswordEmailDto);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route(DELETE_ACCOUNT_ROUTE)]
        public async Task<IActionResult> DeleteAccountAsync([FromQuery] string userId)
        {
            try
            {
                await this._accountService.DeleteAccountAsync(userId);

                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
