using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Models.CommentsModels;
using MyPregnancyTracker.Services.Services.CommentsService;
using SendGrid.Helpers.Errors.Model;
using static MyPregnancyTracker.Web.Constants.Constants.CommentsControllerRoutes;
namespace MyPregnancyTracker.Web.Controllers
{
    [Route(COMMENTS_ROUTE)]
    public class CommentsController : BaseController
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this._commentsService = commentsService;
        }

        [HttpPost]
        [Route(GET_ALL_COMMENTS_ROUTE)]
        public async Task<IActionResult> GetAllAsync([FromBody] GetAllCommentsRequestDto getAllCommentsRequest)
        {
            try
            {
                var comments = await _commentsService.GetAllAsync(getAllCommentsRequest);

                return Ok(comments);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route(ADD_COMMENT_ROUTE)]
        public async Task<IActionResult> AddAsync([FromBody] AddCommentRequestDto addCommentRequestDto)
        {
            var result = await this._commentsService.AddAsync(addCommentRequestDto);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route(DELETE_COMMENT_ROUTE)]
        public async Task<IActionResult> DeleteAsync([FromQuery] int commentId, [FromQuery] string userId)
        {
            var result = await this._commentsService.DeleteAsync(commentId, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Route(EDIT_COMMENT_ROUTE)]
        public async Task<IActionResult> EditAsync([FromBody] EditCommentDto commentDto, [FromQuery]
        string userId)
        {
           var result = await this._commentsService.EditAsync(commentDto, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [Route(GET_USER_COMMENTS_ROUTE)]
        public async Task<IActionResult> GetUserCommentsAsync([FromQuery] int topicId, [FromQuery] string userId)
        {
            try
            {
                var comments = await this._commentsService.GetUserCommentsAsync(userId, topicId);

                return Ok(comments);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }
    }
}
