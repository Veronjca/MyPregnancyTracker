using MyPregnancyTracker.Services.Models.ReactionsModels;

namespace MyPregnancyTracker.Services.Services.ReactionsService
{
    public interface IReactionsService
    {

        /// <summary>
        /// Add new reaction to the database, as asynchronous operation.
        /// </summary>
        /// <param name="addDeleteReactionRequest">The model that holds request info.</param>
        /// <returns>A model that holds user reactions and all comments for the topic.</returns>
        Task<AddDeleteReactionResponseDto> AddToCommentAsync(AddDeleteReactionRequestDto addDeleteReactionRequest);

        /// <summary>
        /// Sets deleted on property of the specified reaction, as asynchronous operation.
        /// </summary>
        /// <param name="addDeleteReactionRequest">The model that holds request info.</param>
        /// <returns>A model that holds user reactions and all comments for the topic.</returns>
        Task<AddDeleteReactionResponseDto> DeleteFromCommentAsync(AddDeleteReactionRequestDto addDeleteReactionRequest);

        /// <summary>
        /// Gets all user reactions for the specified comment, as asynchronous operation.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>A collection of the user's reactions.</returns>
        Task<List<ReactionDto>> GetUserReactionsAsync(string userId);
    }
}
