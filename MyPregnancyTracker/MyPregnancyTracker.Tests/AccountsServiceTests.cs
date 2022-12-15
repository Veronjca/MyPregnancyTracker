using MyPregnancyTracker.Services.Models.AccountsModels;
using MyPregnancyTracker.Services.Services.AccountService;
using MyPregnancyTracker.Services.Services.EmailService;
using MyPregnancyTracker.Services.Services.TasksService;
using MyPregnancyTracker.Services.Services.UserService;

namespace MyPregnancyTracker.Tests
{
    public class AccountsServiceTests : SetUp
    {
        private IEmailService _emailService;
        private IUserService _userService;
        private IAccountService _accountService; 
        private ITasksService _tasksService; 

        [SetUp]
        public async Task Setup()
        {
            await InitializeDatabase();

            var userManager = GetUserManager();
            var configuration = GetIConfiguration();
            var usersRepository = GetUserRepository();
            var mapper = GetMapper();
            var emailSender = GetEmailSender();
            var appSettingsOptions = GetApplicationSettingsOptions();
            var dataProtectionProvider = GetProtectionProvider();
            var userRepository = GetUserRepository();
            var usersTasksRepository = GetUsersTasksRepository();
            var tasksRepository = GetTaskRepository();

            this._emailService = new EmailService(emailSender, appSettingsOptions, dataProtectionProvider, configuration);
            this._tasksService = new TasksService(userManager, configuration, dataProtectionProvider, userRepository, tasksRepository, usersTasksRepository, mapper);
            this._userService = new UserService(configuration, dataProtectionProvider, userManager, userRepository, usersTasksRepository, this._tasksService);
            this._accountService = new AccountService(userManager, configuration, usersRepository, mapper, this._emailService, this._userService, dataProtectionProvider);
        }

        [Test]
        public async Task SignUpShouldWorkProperly()
        {
            var registerDto = new RegisterDto
            {
                Email = "mimi@abv.bg",
                FirstDayOfLastMenstruation = DateTime.Now,
                UserName = "MimeMamaMu",
                Password = "A123456a!",
                ConfirmPassword = "A123456a!"       
            };

            var result = await this._accountService.SignUpUserAsync(registerDto);

            Assert.IsTrue(result.Succeeded);
            Assert.That(users.Count == 3);
        }

        [Test]
        public async Task SignInShouldWorkProperly()
        {
            var loginDto = new LoginDto
            {
                Email = "viki@gmail.com",
                Password = "A1234567a@"
            };

            var result = await this._accountService.SignInUserAsync(loginDto);

            Assert.That(loginDto.Email, Is.EqualTo(result.Email));
        }

        [Test]
        public async Task RefreshAccessTokenShouldWorkProperly()
        {
            var refreshAccessTokenDto = new RefreshAccessTokenDto
            {
                UserId = MOCK_USER_ID,
                RefreshToken = MOCK_REFRESH_TOKEN
            };

            var response = await this._accountService.RefreshAccessTokenAsync(refreshAccessTokenDto); 

            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetUserByEmailShouldWorkProperly()
        {
            var result = await this._accountService.GetUserByEmailAsync("viki@gmail.com");

            Assert.IsNotNull(result);
            Assert.That(result.Email, Is.EqualTo("viki@gmail.com"));
            Assert.That(result.UserName, Is.EqualTo("Viki"));
        }

        [Test]
        public async Task GenerateEmailConfimationTokenShouldWorkProperly()
        {
            var token = await this._accountService.GenerateEmailConfirmationTokenAsync(this.users.First());

            Assert.IsNotNull(token);
            Assert.That(token, Is.EqualTo(MOCK_EMAIL_CONFIRMATION_TOKEN));
        }

        [Test]
        public async Task ConfirmEmailAsyncShouldWorkProperly()
        {
            var result = await this._accountService.ConfirmEmailAsync(MOCK_EMAIL_TOKEN, MOCK_USER_ID);

            Assert.IsTrue(result.Succeeded);
        }

        [Test]
        public async Task ResetPasswordAsyncShouldWorkProperly()
        {
            var resetPasswordDto = new ResetPasswordDto
            {
                ProtectedToken = MOCK_RESET_PASSWORD_TOKEN,
                ProtectedEmail = MOCK_PROTECTED_EMAIL,
                NewPassword = "a3047744AAA1!",
                ConfirmNewPassword = "a3047744AAA1!"
            };

            var result = await this._accountService.ResetPasswordAsync(resetPasswordDto);

            Assert.IsTrue(result.Succeeded);
        }

        [Test] 
        public async Task DeleteAccountShouldWorkProperly()
        {
            await this._accountService.DeleteAccountAsync(MOCK_USER_ID);

            Assert.NotNull(this.users.First().DeletedOn);
        }
    }
}