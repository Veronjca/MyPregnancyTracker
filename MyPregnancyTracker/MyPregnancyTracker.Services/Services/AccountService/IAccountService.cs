using Microsoft.AspNetCore.Identity;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.AccountsModels;

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
        /// Generates user confirmation email token, as asynchronous operation.
        /// </summary>
        /// <param name="user">The user itself.</param>
        /// <returns>The generated token to use for email confirmation.</returns>
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);

        /// <summary>
        /// Confirm the user email, as asynchronous operation.
        /// </summary>
        /// <param name="emailToken">The token to use for confirmation.</param>
        /// <param name="userId">The user id.</param>
        /// <returns>If the email confirmation is successful.</returns>
        Task<IdentityResult> ConfirmEmailAsync(string emailToken, string userId);

        /// <summary>
        /// Change user's password, as asynchronous operation.
        /// </summary>
        /// <param name="resetPasswordDto">The model that holds user's email, old password and new password.</param>
        /// <returns>If the reset is successful.</returns>
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);

        /// <summary>
        /// Refesh the user's access token, as asynchronous operation.
        /// </summary>
        /// <param name="refreshAccessTokenDto">The model that holds user's email and refresh token.</param>
        /// <returns>The model that holds the newly generated access and refresh token.</returns>
        Task<RefreshAccessTokenResponseDto> RefreshAccessTokenAsync(RefreshAccessTokenDto refreshAccessTokenDto);

        /// <summary>
        /// Sending reset password email to the user, as asynchronous operation.
        /// </summary>
        /// <param name="resetPasswordEmailDto">The model that holds user's email.</param>
        Task SendResetPasswordEmailAsync(ResetPasswordEmailDto resetPasswordEmailDto);

        /// <summary>
        /// Update user's profile information, as asynchronous operation.
        /// </summary>
        /// <param name="updateUserProfileRequest">The model that holds user's id, first name, last name, birthdate, weight, height and due date.</param>
        Task UpdateUserProfileData(UpdateUserProfileRequest updateUserProfileRequest);

        /// <summary>
        /// Getting user's profile information, as asynchronous operation.
        /// </summary>
        /// <param name="userId">The user's id used to get the user from database.</param>
        Task<GetUserProfileDataResponse> GetUserProfileData(string userId);
    }
}
