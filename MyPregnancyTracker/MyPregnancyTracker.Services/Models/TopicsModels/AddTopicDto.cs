
using MyPregnancyTracker.Data.Enums;

namespace MyPregnancyTracker.Services.Models.TopicsModels
{
    public class AddTopicDto
    {
        public string UserId { get; set; }

        public TopicCategoryEnum Category { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }
    }
}
