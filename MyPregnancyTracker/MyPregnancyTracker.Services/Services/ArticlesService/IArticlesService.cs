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
        /// Gets one article by id, as asynchronous operation.
        /// </summary>
        /// <param name="articleId">The article id.</param>
        /// <param name="userId">The user id. Needed to get article likes.</param>
        /// <returns>A model that holds the article properties.</returns>
        Task<ArticleDto> GetOneByIdAsync(int articleId, string userId);

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
        /// <returns>A model that represents the changed article.</returns>
        Task<ArticleDto> AddReactionAsync(AddReactionToArticleRequestDto addReactionToArticleRequest);

        /// <summary>
        /// Add new article to the database, as asynchronous operation.
        /// </summary>
        /// <param name="addArticleRequest">The model that holds the request info.</param>
        /// <returns><see langword="true"/> if the operation succeeded else <see langword="false"/>.</returns>
        Task<bool> AddAsync(AddArticleRequestDto addArticleRequest);

        /// <summary>
        /// Searching for matching articles using elasticsearch client, as asynchronous operation.
        /// </summary>
        /// <param name="searchTerm">The search parameter used to match articles.</param>
        /// <returns>A collection with the matched articles.</returns>
        Task<IEnumerable<ArticleDto>> SearchAsync(string searchTerm);
    }
}
