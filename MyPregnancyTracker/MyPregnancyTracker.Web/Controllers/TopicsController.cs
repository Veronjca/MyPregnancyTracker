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

        [HttpPost]
        [Route(GET_ALL_TOPICS_ROUTE)]
        public async Task<IActionResult> GetAllAsync([FromBody] GetAllTopicsRequestDto getAllTopicsRequest)
        {
            var topics = await this._topicsService.GetAllAsync(getAllTopicsRequest);

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
        public async Task<IActionResult> AddAsync([FromBody] AddTopicDto addTopicDto)
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

        [HttpDelete]
        [Route(DELETE_TOPIC_ROUTE)]
        public async Task<IActionResult> DeleteAsync([FromQuery] int topicId, [FromQuery] string userId)
        {
            var result = await this._topicsService.DeleteTopicAsync(topicId, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route(EDIT_TOPIC_ROUTE)]
        public async Task<IActionResult> EditAsync([FromBody]TopicDto topicDto, [FromQuery]string userId)
        {
            var result = await this._topicsService.EditTopicAsync(topicDto, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
