﻿using MyPregnancyTracker.Services.Models.TopicsModels;

namespace MyPregnancyTracker.Services.Services.TopicsService
{
    public interface ITopicsService
    {
        /// <summary>
        /// Gets all topics for the specified category, as asynchronous operation.
        /// </summary>
        /// <param name="getAllTopicsRequest">The model that holds the request info.</param>
        /// <returns>Returns a model that holds paged and ordered topics.</returns>
        Task<GetAllTopicsResponseDto> GetAllAsync(GetAllTopicsRequestDto getAllTopicsRequest);

        /// <summary>
        /// Gets topic by id, as asynchronous operation.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <returns>The specified topic.</returns>
        Task<TopicDto> GetOneAsync(int topicId);

        /// <summary>
        /// Gets all topics from the specified user, as asynchronous operation.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>A collection of the user's topics.</returns>
        Task<List<TopicDto>> GetUserTopicsAsync(string userId);

        /// <summary>
        /// Add new topic to the database, as asynchronous operation.
        /// </summary>
        /// <param name="addTopicDto">The model that holds topic's title, content, user id and category.</param>
        /// <returns><see langword="true"/> if the operation succeeded else <see langword="false"/>.</returns>
        Task<bool> AddTopicAsync(AddTopicDto addTopicDto);

        /// <summary>
        /// Sets deleted on property of the specified topic, as asynchronous operation.
        /// </summary>
        /// <param name="topicId">The topic id.</param>
        /// <param name="userId">The user id of the author.</param>
        /// <returns><see langword="true"/> if the operation succeeded else <see langword="false"/>.</returns>
        Task<bool> DeleteTopicAsync(int topicId, string userId);

        /// <summary>
        /// Edits the specified topic, as asynchronous operation.
        /// </summary>
        /// <param name="topicDto">The model that holds the new info.</param>
        /// <param name="userId">The id of the user that initialize the edit request.</param>
        /// <returns><see langword="true"/> if the operation succeeded else <see langword="false"/>.</returns>
        Task<bool> EditTopicAsync(TopicDto topicDto, string userId);

    }
}
