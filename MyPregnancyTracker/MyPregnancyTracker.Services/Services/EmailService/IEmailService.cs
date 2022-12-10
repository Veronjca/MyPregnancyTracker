using MyPregnancyTracker.Data.Models;

namespace MyPregnancyTracker.Services.Services.EmailService
{
    public interface IEmailService
    {
        /// <summary>
        /// Sending confirmation email to the registered user, as asynchronous operation.
        /// </summary>
        /// <param name="user">The user itself.</param>
        /// <param name="token">The token to use for the confirmation.</param>
        Task SendConfirmationEmailAsync(ApplicationUser user, string token);

        /// <summary>
        /// Sending reset password email to the specified user, as asynchronous operation.
        /// </summary>
        /// <param name="user">The user itself.</param>
        /// <param name="token">The token to use for the operation.</param>
        Task SendResetPasswordEmailAsync(ApplicationUser user, string token);
    }
}
