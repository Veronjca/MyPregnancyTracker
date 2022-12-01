using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route(GET_ALL_COMMENTS_ROUTE)]
        public async Task<IActionResult> GetAllAsync([FromQuery] int topicId)
        {
            try
            {
                var comments = await _commentsService.GetAllAsync(topicId);

                return Ok(comments);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }

    }
}
