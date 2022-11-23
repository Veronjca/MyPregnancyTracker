using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.GestationalWeekModels;

namespace MyPregnancyTracker.Services.Services.GestationalWeekService
{
    public interface IGestationalWeekService
    {
        /// <summary>
        /// Gets all gestational weeks, as asynchronous operation.
        /// </summary>
        Task<List<GestationalWeekDto>> GetAllAsync();

        /// <summary>
        /// Gets specific gestational week, as asynchronous operation.
        /// </summary>
        /// <param name="gestationalAge">The gestational age of the gestational week.</param>
        Task<GestationalWeek> GetOneAsync(int gestationalAge);
    }
}
