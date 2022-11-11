using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Models;
using static MyPregnancyTracker.Web.Constants.Constants.Route;
using MyPregnancyTracker.Services.Services.AccountService;
using MyPregnancyTracker.Services.Services.EmailService;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using SendGrid.Helpers.Errors.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(ACCOUNTS_ROUTE)]
    public class AccountsController : BaseController
    {
        //ForgotPassword

        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;
        private readonly IDataProtector _dataProtector;
        private readonly IConfiguration _configuration;
        public AccountsController(
            IAccountService accountService,
            IEmailService emailService,
            IDataProtectionProvider dataProtectionProvider,
            IConfiguration configuration)
        {
            this._accountService = accountService;
            this._emailService = emailService;
            this._configuration = configuration;
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
            catch (BadRequestException ex)
            {
                return NotFound(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
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
            catch (NullReferenceException)
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
            var result = await _accountService.ResetPasswordAsync(resetPasswordDto);

            if (!result.Succeeded)
            {               
                return BadRequest(result.Errors);
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
                return Unauthorized(ex.Message);
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
            catch (BadRequestException)
            {
                return BadRequest();
            }
        }
    }
}
