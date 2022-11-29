using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Models.TopicsModels;
using MyPregnancyTracker.Services.Services.TopicsService;
using static MyPregnancyTracker.Web.Constants.Constants.TopicsControllerRoutes;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(TOPICS_ROUTE)]
    public class TopicsController : BaseController
    {
        private readonly ITopicsService _topicsService;

        public TopicsController(ITopicsService topicsService)
        {
            this._topicsService = topicsService;
        }

        [HttpGet]
        [Route(GET_ALL_TOPICS_ROUTE)]
        public async Task<IActionResult> GetAllAsync([FromQuery] int category)
        {
            var topics = await this._topicsService.GetAllAsync(category);

            return Ok(topics);
        }

        [HttpPost]
        [Route(ADD_TOPIC_ROUTE)]
        public async Task<IActionResult> AddTopicAsync([FromBody] AddTopicDto addTopicDto)
        {
            var result = await this._topicsService.AddTopicAsync(addTopicDto);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
