using MyPregnancyTracker.Services.Models.ArticlesModels;

namespace MyPregnancyTracker.Services.Services.ArticlesService
{
    public interface IArticlesService
    {
        /// <summary>
        /// Gets all articles, as asynchronous operation.
        /// </summary>
        /// <param name="getAllArticlesRequest">The model that holds the request info.</param>
        /// <returns>A model that holds a collection of mapped articles and their count.</returns>
        Task<GetAllArticlesResponseDto> GetAllAsync(GetAllArticlesRequestDto getAllArticlesRequest);

        /// <summary>
        /// Sets deleted on property of the specified article, as asynchronous operation.
        /// </summary>
        /// <param name="articleId">The article id.</param>
        /// <param name="userId">The user id.</param>
        /// <returns><see langword="true"/> if the operation succeeded else <see langword="false"/>.</returns>
        Task<bool> DeleteAsync(int articleId, string userId);

        /// <summary>
        /// Edits the specified article, as asynchronous operation.
        /// </summary>
        /// <param name="editArticleRequest">The model that holds the new info.</param>
        /// <param name="userId">The id of the user that initialize the edit request.</param>
        /// <returns><see langword="true"/> if the operation succeeded else <see langword="false"/>.</returns>
        Task<bool> EditAsync(EditArticleRequestDto editArticleRequest, string userId);

        /// <summary>
        /// Add new record to the UsersArticles table, as asynchronous operation.
        /// </summary>
        /// <param name="addReactionToArticleRequest">The model that holds the request info.</param>
        /// <returns>A model that holds all articles mapped.</returns>
        Task<AddReactionToArticleResponseDto> AddReactionAsync(AddReactionToArticleRequestDto addReactionToArticleRequest);

        /// <summary>
        /// Add new article to the database, as asynchronous operation.
        /// </summary>
        /// <param name="addArticleRequest">The model that holds the request info.</param>
        /// <returns><see langword="true"/> if the operation succeeded else <see langword="false"/>.</returns>
        Task<bool> AddAsync(AddArticleRequestDto addArticleRequest);
    }
}
