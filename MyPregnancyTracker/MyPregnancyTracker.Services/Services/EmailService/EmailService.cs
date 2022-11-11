using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Config;
using MyPregnancyTracker.Services.EmailSender;
using System.Reflection;
using System.Text;
using static MyPregnancyTracker.Services.Constants.Constants.Email;

namespace MyPregnancyTracker.Services.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;
        private readonly IDataProtector _dataProtector;
        private readonly IConfiguration _configuration;
        private readonly MyPregnancyTrackerApplicationSettings _ngAppSettings;

        public EmailService(IEmailSender emailSender,
            IOptions<MyPregnancyTrackerApplicationSettings> ngAppSettings,
            IDataProtectionProvider dataProtectionProvider,
            IConfiguration configuration)
        {
            this._ngAppSettings = ngAppSettings.Value;
            this._emailSender = emailSender;
            this._configuration = configuration;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }
        public async Task SendConfirmationEmailAsync(ApplicationUser user, string token)
        {
            string protectedToken = this._dataProtector.Protect(token);
            string protectedUserId = this._dataProtector.Protect(user.Id.ToString());
            string htmlContent = GenerateHTMLContent(protectedToken, _ngAppSettings.ConfirmEmailTemplatePath, protectedUserId, _ngAppSettings.ConfirmEmailPageUrl, new string[] {"emailToken", "userId"});

            await this._emailSender.SendEmailAsync(FROM, FROM_NAME, user.Email, EMAIL_CONFIRMATION_SUBJECT, htmlContent);
        }
        public async Task SendResetPasswordEmailAsync(ApplicationUser user, string token)
        {
            string protectedToken = this._dataProtector.Protect(token);
            string protectedEmail = this._dataProtector.Protect(user.Email);
            string htmlContent = GenerateHTMLContent(protectedToken, _ngAppSettings.ResetPasswordEmailTemplatePath, protectedEmail, _ngAppSettings.ResetPasswordPageUrl, new string[] { "passwordToken", "email" });

            await this._emailSender.SendEmailAsync(FROM, FROM_NAME, user.Email, RESET_PASSWORD_SUBJECT, htmlContent);
        }

        private string GenerateHTMLContent(string token, string templatePath, string userInfo, string pageUrl, params string [] queryParamsNames)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + templatePath;
            string htmlContentAsString = File.ReadAllText(path);

            string uri = $"{_ngAppSettings.BaseUrl}/{pageUrl}?{queryParamsNames[0]}={token}&{queryParamsNames[1]}={userInfo}"; 
            string formattedHtmlContent = string.Format(htmlContentAsString, uri);
            return formattedHtmlContent;
        }
    }
}
