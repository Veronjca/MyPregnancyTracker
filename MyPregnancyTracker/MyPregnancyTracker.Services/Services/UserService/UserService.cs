using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models.AccountsModels;
using SendGrid.Helpers.Errors.Model;

namespace MyPregnancyTracker.Services.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<ApplicationUser> _userRepository;
        private readonly IDataProtector _dataProtector;

        public UserService(IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUser> userRepository)
        {
            this._configuration = configuration;
            this._userManager = userManager;
            this._userRepository = userRepository;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }

        public async Task SetDueDateAsync(ApplicationUser user, DateTime firstDayOfLastMenstruation)
        {
            //Pregnancy duration is 10 months x 28 days.
            var dueDate = firstDayOfLastMenstruation.AddDays(280);
            user.DueDate = dueDate;

            this._userRepository.Update(user);
            await this._userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserProfileDataAsync(UpdateUserProfileRequest updateUserProfileRequest)
        {
            var userId = this._dataProtector.Unprotect(updateUserProfileRequest.UserId);
            var user = await this._userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new BadRequestException();
            }

            user.FirstName = updateUserProfileRequest.FirstName;
            user.LastName = updateUserProfileRequest.LastName;
            user.BirthDate = updateUserProfileRequest.BirthDate;
            user.Weight = updateUserProfileRequest.Weight;
            user.Height = updateUserProfileRequest.Height;

            if (updateUserProfileRequest.DueDate.HasValue)
            {
                user.DueDate = updateUserProfileRequest.DueDate.Value;
            }

            this._userRepository.Update(user);
            await this._userRepository.SaveChangesAsync();
        }

        public async Task<GetUserProfileDataResponse> GetUserProfileDataAsync(string userId)
        {
            var user = await this._userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new BadRequestException();
            }

            var response = new GetUserProfileDataResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate.HasValue ? user.BirthDate.Value.ToLocalTime() : null,
                Height = user.Height,
                Weight = user.Weight,
                DueDate = user.DueDate.ToLocalTime(),
            };

            return response;
        }
    }
}
