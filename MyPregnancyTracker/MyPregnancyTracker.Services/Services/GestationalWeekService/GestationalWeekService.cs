
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models.GestationalWeekModels;

namespace MyPregnancyTracker.Services.Services.GestationalWeekService
{
    public class GestationalWeekService : IGestationalWeekService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<GestationalWeek> _gestationalWeekRepository;
        private readonly IDataProtector _dataProtector;

        public GestationalWeekService(IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            IRepository<GestationalWeek> gestationalWeekRepository)
        {
            this._configuration = configuration;
            this._gestationalWeekRepository = gestationalWeekRepository;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }

        public async Task<List<GestationalWeekDto>> GetAllAsync()
        {
            var gestationalWeeks = await this._gestationalWeekRepository
                .GetAll()
                .Select(gs => new GestationalWeekDto
                {
                    Id = this._dataProtector.Protect(gs.Id.ToString()),
                    BabyContent = gs.BabyContent,
                    AdvicesContent = gs.AdvicesContent,
                    GestationalAge = gs.GestationalAge,
                    MotherContent = gs.MotherContent,
                    NutritionContent = gs.NutritionContent  
                })
                .ToListAsync();

            return gestationalWeeks;
        }

        public async Task<GestationalWeek> GetOneAsync(int gestationalAge)
        {
            return await this._gestationalWeekRepository
                .GetAll()
                .Where(gs => gs.GestationalAge == gestationalAge)
                .FirstAsync();
        }
    }
}
