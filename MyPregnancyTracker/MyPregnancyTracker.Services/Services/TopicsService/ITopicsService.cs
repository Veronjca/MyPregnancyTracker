using MyPregnancyTracker.Services.Models.TopicsModels;

namespace MyPregnancyTracker.Services.Services.TopicsService
{
    public interface ITopicsService
    {
        /// <summary>
        /// Get all topics for the specified category, as asynchronous operation.
        /// </summary>
        /// <param name="category">The number representation of category.</param>
        /// 
        Task<List<TopicDto>> GetAllAsync(int category);

        /// <summary>
        /// Add new topic to the database, as asynchronous operation.
        /// </summary>
        /// <param name="addTopicDto">The model that holds topic's title, content, user id and category.</param>
        /// 
        Task<bool> AddTopicAsync(AddTopicDto addTopicDto);

    }
}
