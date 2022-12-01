using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Models.TopicsModels;
using MyPregnancyTracker.Services.Services.TopicsService;
using SendGrid.Helpers.Errors.Model;
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

        [HttpGet]
        [Route(GET_ONE_TOPIC_ROUTE)]
        public async Task<IActionResult> GetOneAsync([FromQuery] int topicId)
        {
            var topic = await this._topicsService.GetOneAsync(topicId);

            return Ok(topic);
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

        [HttpGet]
        [Route(GET_USER_TOPICS_ROUTE)]
        public async Task<IActionResult> GetUserTopicsAsync([FromQuery] string userId)
        {
            try
            {
                var topics = await this._topicsService.GetUserTopicsAsync(userId);

                return Ok(topics);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }                    
        }

        [HttpGet]
        [Route(DELETE_TOPIC_ROUTE)]
        public async Task<IActionResult> DeleteTopicAsync([FromQuery] int topicId)
        {
            var result = await this._topicsService.DeleteTopicAsync(topicId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route(EDIT_TOPIC_ROUTE)]
        public async Task<IActionResult> EditTopicAsync([FromBody]TopicDto topicDto)
        {
            var result = await this._topicsService.EditTopicAsync(topicDto);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
