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
    }
}
