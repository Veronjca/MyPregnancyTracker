using static MyPregnancyTracker.Web.Constants.Constants.ArticlesControllerRoutes;
using static MyPregnancyTracker.Web.Constants.Constants.Role;
using MyPregnancyTracker.Services.Services.ArticlesService;
using Microsoft.AspNetCore.Mvc;
using MyPregnancyTracker.Services.Models.ArticlesModels;
using SendGrid.Helpers.Errors.Model;
using Microsoft.AspNetCore.Authorization;

namespace MyPregnancyTracker.Web.Controllers
{
    [Route(ARTICLES_ROUTE)]
    public class ArticlesController : BaseController
    {
        private readonly IArticlesService _articlesService;

        public ArticlesController(IArticlesService articlesService)
        {
            this._articlesService = articlesService;
        }

        [HttpPost]
        [Route(GET_ALL_ARTICLES_ROUTE)]
        public async Task<IActionResult> GetAllAsync(GetAllArticlesRequestDto getAllArticlesRequest)
        {
            try
            {
                var articles = await this._articlesService.GetAllAsync(getAllArticlesRequest);

                return Ok(articles);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route(GET_ONE_ARTICLE_ROUTE)]
        public async Task<IActionResult> GetOneByIdAsync([FromQuery]int articleId, [FromQuery] string userId)
        {
            try
            {
                var article = await this._articlesService.GetOneByIdAsync(articleId, userId);

                return Ok(article);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Authorize(Roles = ADMIN_ROLE)]
        [Route(DELETE_ARTICLE_ROUTE)]
        public async Task<IActionResult> DeleteAsync([FromQuery] int articleId, [FromQuery] string userId)
        {
            var result = await this._articlesService.DeleteAsync(articleId, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = ADMIN_ROLE)]
        [Route(EDIT_ARTICLE_ROUTE)]
        public async Task<IActionResult> EditAsync([FromBody] EditArticleRequestDto editArticleRequest, [FromQuery] string userId)
        {
            var result = await this._articlesService.EditAsync(editArticleRequest, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        [Route(ADD_REACTION_ROUTE)]
        public async Task<IActionResult> AddReactionAsync([FromBody]AddReactionToArticleRequestDto addReactionToArticleRequest)
        {         
            try
            {
                var response = await this._articlesService.AddReactionAsync(addReactionToArticleRequest);

                return Ok(response);
            }
            catch (NotFoundException)
            {
                return BadRequest();
            }        
        }

        [HttpPost]
        [Authorize(Roles = ADMIN_ROLE)]
        [Route(ADD_ARTICLE_ROUTE)]
        public async Task<IActionResult> AddArticleAsync([FromBody]AddArticleRequestDto addArticleRequest)
        {
            var result = await this._articlesService.AddAsync(addArticleRequest);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
