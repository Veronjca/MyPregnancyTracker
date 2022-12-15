
using MyPregnancyTracker.Services.Services.EmailService;

namespace MyPregnancyTracker.Tests
{
    public class EmailServiceTests : SetUp
    {
        private IEmailService _emailService;
        [SetUp]
        public async Task SetUp()
        {
            await InitializeDatabase();

            var emailSender = GetEmailSender();
            var appSettings = GetApplicationSettingsOptions();
            var dataProtector = GetProtectionProvider();
            var configuration = GetIConfiguration();

            this._emailService = new EmailService(emailSender, appSettings, dataProtector, configuration);  
        }

        [Test]
        public async Task SendConfirmationEmailShouldNotThrowError()
        {
            var user = users.First();
            var token = MOCK_EMAIL_CONFIRMATION_TOKEN;

            Assert.DoesNotThrowAsync(async () => await this._emailService.SendConfirmationEmailAsync(user, token)); 
        }

        [Test]
        public async Task SendResetPasswordEmailShouldNotThrowError()
        {
            var user = users.First();
            var token = MOCK_EMAIL_CONFIRMATION_TOKEN;

            Assert.DoesNotThrowAsync(async () => await this._emailService.SendResetPasswordEmailAsync(user, token));
        }
    }
}
