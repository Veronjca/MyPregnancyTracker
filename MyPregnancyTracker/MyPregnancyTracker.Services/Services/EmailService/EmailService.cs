using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Config;
using MyPregnancyTracker.Services.EmailSender;
using System.Reflection;
using System.Text;
using static MyPregnancyTracker.Services.Constants.Constants.Common;
using static MyPregnancyTracker.Services.Constants.Constants.Email;

namespace MyPregnancyTracker.Services.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;
        private readonly MyPregnancyTrackerApplicationSettings _ngAppSettings;

        public EmailService(IEmailSender emailSender,
            IOptions<MyPregnancyTrackerApplicationSettings> ngAppSettings)
        {
            this._ngAppSettings = ngAppSettings.Value;
            this._emailSender = emailSender;
        }
        public async Task SendConfirmationEmailAsync(ApplicationUser user, string token)
        {
            string encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            string encodedUserId = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(user.Id.ToString()));
            string htmlContent = GenerateHTMLContent(CONFIRMATION_EMAIL_HTML_TEMPLATE_FILE_NAME, encodedToken, encodedUserId, _ngAppSettings.ConfirmEmailPageUrl, new string[] {"emailToken", "userId"});

            await this._emailSender.SendEmailAsync(FROM, FROM_NAME, user.Email, EMAIL_CONFIRMATION_SUBJECT, htmlContent);
        }
        public async Task SendResetPasswordEmailAsync(ApplicationUser user, string token)
        {
            string encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            string encodedEmail = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(user.Email.ToString()));
            string htmlContent = GenerateHTMLContent(RESET_PASSWORD_EMAIL_HTML_TEMPLATE_FILE_NAME, encodedToken, encodedEmail, _ngAppSettings.ResetPasswordPageUrl, new string[] { "passwordToken", "email" });

            await this._emailSender.SendEmailAsync(FROM, FROM_NAME, user.Email, RESET_PASSWORD_SUBJECT, htmlContent);
        }

        private string GenerateHTMLContent(string fileName, string token, string userInfo, string pageUrl, params string [] queryParamsNames)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"/EmailSender/Templates/{fileName}";
            string htmlContentAsString = File.ReadAllText(path);

            string uri = $"{_ngAppSettings.BaseUrl}/{pageUrl}?{queryParamsNames[0]}={token}&{queryParamsNames[1]}={userInfo}"; 
            string formattedHtmlContent = string.Format(htmlContentAsString, uri);
            return formattedHtmlContent;
        }
    }
}
