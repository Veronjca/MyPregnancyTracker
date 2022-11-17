using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.AccountsModels;

namespace MyPregnancyTracker.Services.Services.UserService
{
    public interface IUserService
    {
        /// <summary>
        /// Calculates and sets user's due date, as asynchronous operation.
        /// </summary>
        /// <param name="user">The user which due date needs to be set.</param>
        /// <param name="firstDayOfLastMenstruation">String represantation of the user's first day of last menstruation date used for calculating due date.</param>
        Task SetDueDateAsync(ApplicationUser user, DateTime firstDayOfLastMenstruation);


        /// <summary>
        /// Update user's profile information, as asynchronous operation.
        /// </summary>
        /// <param name="updateUserProfileRequest">The model that holds user's id, first name, last name, birthdate, weight, height and due date.</param>
        Task UpdateUserProfileDataAsync(UpdateUserProfileRequest updateUserProfileRequest);

        /// <summary>
        /// Getting user's profile information, as asynchronous operation.
        /// </summary>
        /// <param name="userId">The user's id used to get the user from database.</param>
        Task<GetUserProfileDataResponse> GetUserProfileDataAsync(string userId);
    }
}
