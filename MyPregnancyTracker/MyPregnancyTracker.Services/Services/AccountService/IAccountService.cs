using MyPregnancyTracker.Services.Models;

namespace MyPregnancyTracker.Services.Services.AccountService
{
    public interface IAccountService
    {
        /// <summary>
        /// Authenticates the user. Sign in user with password and email.
        /// </summary>
        /// <param name="loginDto">Model containing the user email and password.</param>
        /// <returns>Model containing user's Id, UserName, Email, AccessToken and RefreshToken.</returns>
        Task<LoginResponseDto> SignInUser(LoginDto loginDto);
    }
}
