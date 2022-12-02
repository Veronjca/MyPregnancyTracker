using MyPregnancyTracker.Services.Models.CommentsModels;

namespace MyPregnancyTracker.Services.Services.CommentsService
{
    public interface ICommentsService
    {
        /// <summary>
        /// Gets all comments for the specified topic, as asynchronous operation.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns>Returns a collection of mapped comments.</returns>
        Task<List<CommentDto>> GetAllAsync(int topicId);

        /// <summary>
        /// Adding comment for the specified topic, as asynchronous operation.
        /// </summary>
        /// <param name="addCommentRequestDto">The model that holds the user id, the topic id and comment content.</param>
        /// <returns><see langword="true"/> if the operation succeeded else <see langword="false"/>.</returns>
        Task<bool> AddAsync(AddCommentRequestDto addCommentRequestDto);

        /// <summary>
        /// Sets deleted on property of the specified comment, as asynchronous operation.
        /// </summary>
        /// <param name="commentId">The comment id.</param>
        /// <param name="userId">The user id of the author.</param>
        /// <returns><see langword="true"/> if the operation succeeded else <see langword="false"/>.</returns>
        Task<bool> DeleteAsync(int commentId, string userId);

        /// <summary>
        /// Edits the content of the specified comment, as asynchronous operation.
        /// </summary>
        /// <param name="commentDto">The model that holds the edited comment content.</param>
        /// <returns><see langword="true"/> if the operation succeeded else <see langword="true"/>.</returns>
        Task<bool> EditAsync(EditCommentDto commentDto);

        /// <summary>
        /// Gets all comments from the specified user of the specified topic, as asynchronous operation.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="topicId">The topic id.</param>
        /// <returns>A collection of the user's comments for the specified topic.</returns>
        Task<List<CommentDto>> GetUserCommentsAsync(string userId, int topicId);
    }
}
