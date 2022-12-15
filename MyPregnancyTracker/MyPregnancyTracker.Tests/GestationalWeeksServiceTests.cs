using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Services.GestationalWeekService;

namespace MyPregnancyTracker.Tests
{
    public class GestationalWeeksServiceTests : SetUp
    {
        private IGestationalWeekService _gestationalWeekService;

        [SetUp]
        public async Task SetUp()
        {
            await InitializeDatabase();

            var configuration = GetIConfiguration();
            var dataProtector = GetProtectionProvider();
            var gestationalWeeksRepository = GetGestationalWeekRepository();

            this._gestationalWeekService = new GestationalWeekService(configuration, dataProtector, gestationalWeeksRepository);
        }

        [Test]
        public async Task GetAllShouldWorkProperly()
        {
            var result = await this._gestationalWeekService.GetAllAsync();

            var expectedGestationalWeekCount = context.Set<GestationalWeek>().Count();
                
            Assert.IsNotNull(result); 
            Assert.That(result.Count, Is.EqualTo(expectedGestationalWeekCount));
        }

        [Test]
        public async Task GetOneShouldWorkProperly()
        {
            int gestationalAge = 1;

            var result = await this._gestationalWeekService.GetOneAsync(gestationalAge);

            var expectedGestationalWeek = context.Set<GestationalWeek>()
                .FirstOrDefault(gs => gs.GestationalAge == gestationalAge);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(expectedGestationalWeek.Id));
        }
    }
}
