using MyPregnancyTracker.Services.Models.TopicsModels;

namespace MyPregnancyTracker.Services.Services.TopicsService
{
    public interface ITopicsService
    {
        /// <summary>
        /// Gets all topics for the specified category, as asynchronous operation.
        /// </summary>
        /// <param name="category">The number representation of category.</param>
        /// <returns>Returns a collection of mapped topics.</returns>
        Task<List<TopicDto>> GetAllAsync(int category);

        /// <summary>
        /// Gets topic by id, as asynchronous operation.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        Task<TopicDto> GetOneAsync(int topicId);

        /// <summary>
        /// Gets all topics from the specified user, as asynchronous operation.
        /// </summary>
        /// <param name="userId">The user id.</param>
        Task<List<TopicDto>> GetUserTopicsAsync(string userId);

        /// <summary>
        /// Add new topic to the database, as asynchronous operation.
        /// </summary>
        /// <param name="addTopicDto">The model that holds topic's title, content, user id and category.</param>
        Task<bool> AddTopicAsync(AddTopicDto addTopicDto);

        /// <summary>
        /// Sets deleted on property of the specified topic, as asynchronous operation.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns>True if the operation succeeded else false.</returns>
        Task<bool> DeleteTopicAsync(int topicId);

        /// <summary>
        /// Edits the specified topic, as asynchronous operation.
        /// </summary>
        /// <param name="topicDto">The model that holds the new info.</param>
        /// <returns>True if the operation succeeded else false.</returns>
        Task<bool> EditTopicAsync(TopicDto topicDto);

    }
}
