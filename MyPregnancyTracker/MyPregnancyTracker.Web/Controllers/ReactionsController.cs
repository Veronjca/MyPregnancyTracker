using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Models.ReactionsModels;
using MyPregnancyTracker.Services.Services.ReactionsService;
using SendGrid.Helpers.Errors.Model;
using static MyPregnancyTracker.Web.Constants.Constants.ReactionsControllerRoutes;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(REACTIONS_ROUTE)]
    public class ReactionsController : BaseController
    {
        private readonly IReactionsService _reactionsService;

        public ReactionsController(IReactionsService reactionsService)
        {
            this._reactionsService = reactionsService;
        }

        [HttpPost]
        [Route(ADD_REACTION_ROUTE)]
        public async Task<IActionResult> AddToCommentAsync([FromBody] AddDeleteReactionRequestDto addDeleteReactionRequest)
        {
            try
            {
                var result = await this._reactionsService.AddToCommentAsync(addDeleteReactionRequest);

                return Ok(result);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        [Route(DELETE_REACTION_ROUTE)]
        public async Task<IActionResult> DeleteFromCommentAsync([FromBody] AddDeleteReactionRequestDto addDeleteReactionRequest)
        {
            try
            {
                var result = await this._reactionsService.DeleteFromCommentAsync(addDeleteReactionRequest);

                return Ok(result);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
           
        }

        [HttpGet]
        [Route(GET_USER_REACTIONS_ROUTE)]
        public async Task<IActionResult> GetUserReactionsAsync([FromQuery]string userId)
        {
            try
            {
                var reactions = await this._reactionsService.GetUserReactionsAsync(userId);

                return Ok(reactions);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }

    }
}
