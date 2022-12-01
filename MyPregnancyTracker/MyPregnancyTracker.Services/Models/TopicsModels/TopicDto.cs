using MyPregnancyTracker.Data.Enums;

namespace MyPregnancyTracker.Services.Models.TopicsModels
{
    public class TopicDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public TopicCategoryEnum Category { get; set; }
    }
}
