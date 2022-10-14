using Microsoft.AspNetCore.Identity;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.EmailSender;
using MyPregnancyTracker.Services.Models;

namespace MyPregnancyTracker.Services.Services.AccountService
{
    public interface IAccountService
    {
        /// <summary>
        /// Authenticates the user, as asynchronous operation. Sign in user with password and email.
        /// </summary>
        /// <param name="loginDto">Model containing the user email and password.</param>
        /// <returns>Model containing user's Id, UserName, Email, AccessToken and RefreshToken.</returns>
        Task<LoginResponseDto> SignInUserAsync(LoginDto loginDto);

        /// <summary>
        /// Register the user into the system, as asynchronous operation. Register requires FirstName, LastName, UserName, Email, Password, ConfirmPassword and FirstDayOfLastMenstruation.
        /// </summary>
        /// <param name="registerDto">Model containing the above user info.</param>
        /// <returns>If the user is registered successfully.</returns>
        Task<IdentityResult> SignUpUserAsync(RegisterDto registerDto);

        /// <summary>
        /// Get user by email, as asynchronous operation.
        /// </summary>
        /// <param name="email">User's email.</param>
        /// <returns>The specified user.</returns>
        Task<ApplicationUser> GetUserByEmailAsync(string email);

        /// <summary>
        /// Generates user confirmation email token.
        /// </summary>
        /// <param name="user">The user itself.</param>
        /// <returns>The generated token to use for email confirmation.</returns>
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
    }
}
