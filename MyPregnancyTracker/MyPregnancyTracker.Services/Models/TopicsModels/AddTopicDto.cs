using MyPregnancyTracker.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static MyPregnancyTracker.Data.Constants.ValidationConstants.Topic;

namespace MyPregnancyTracker.Services.Models.TopicsModels
{
    public class AddTopicDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public TopicCategoryEnum Category { get; set; }

        [Required]
        [MaxLength(TOPIC_CONTENT_MAX_LENGTH)]
        public string Content { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
