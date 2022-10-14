using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly MyPregnancyTrackerApplicationSettings _ngAppSettings;

        public EmailService(
            UserManager<ApplicationUser> userManager, 
            IEmailSender emailSender,
            IOptions<MyPregnancyTrackerApplicationSettings> ngAppSettings)
        {
            this._ngAppSettings = ngAppSettings.Value;
            this._userManager = userManager;
            this._emailSender = emailSender;
        }
        public async Task SendConfirmationEmailAsync(ApplicationUser user, string token)
        {
            string encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            string encodedUserId = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(user.Id.ToString()));
            string htmlContent = GenerateHTMLContent(CONFIRMATION_EMAIL_HTML_TEMPLATE_FILE_NAME, encodedToken, encodedUserId);
            await this._emailSender.SendEmailAsync(FROM, FROM_NAME, user.Email, SUBJECT, htmlContent);
        }

        private string GenerateHTMLContent(string fileName, string token, string userId)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + $"/EmailSender/Templates/{fileName}";
            string htmlContentAsString = File.ReadAllText(path);

            string uri = $"{_ngAppSettings.BaseUrl}/{_ngAppSettings.ConfirmEmailPageUrl}?emailToken={token}&userId={userId}"; 

            string formattedHtmlContent = string.Format(htmlContentAsString, uri);
            return formattedHtmlContent;
        }
    }
}
