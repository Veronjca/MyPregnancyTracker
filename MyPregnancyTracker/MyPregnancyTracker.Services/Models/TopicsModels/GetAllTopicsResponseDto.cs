
namespace MyPregnancyTracker.Services.Models.TopicsModels
{
    public class GetAllTopicsResponseDto
    {
        public List<TopicDto> Topics { get; set; }

        public int TopicsCount { get; set; }
    }
}
