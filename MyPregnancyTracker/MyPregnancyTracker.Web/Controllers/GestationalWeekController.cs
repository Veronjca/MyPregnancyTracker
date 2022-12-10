using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Services.GestationalWeekService;
using static MyPregnancyTracker.Web.Constants.Constants.GestationalWeekControllerRoutes;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(GESTATIONAL_WEEK_ROUTE)]
    public class GestationalWeekController : BaseController
    {
        private readonly IGestationalWeekService _gestationalWeekService;

        public GestationalWeekController(IGestationalWeekService gestationalWeekService)
        {
            this._gestationalWeekService = gestationalWeekService;
        }


        [HttpGet]
        [Route(GET_ALL)]
        public async Task<IActionResult> GetAllAsync()
        {
            var gestationalWeeks = await this._gestationalWeekService.GetAllAsync();

            return Ok(gestationalWeeks);
        }


        [HttpGet]
        [Route(GET_ONE)]
        public async Task<IActionResult> GetOneAsync(int gestationalAge)
        {
            var gestationalWeek = await this._gestationalWeekService.GetOneAsync(gestationalAge);

            return Ok(gestationalWeek);
        }

    }
}
