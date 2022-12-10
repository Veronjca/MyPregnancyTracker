
namespace MyPregnancyTracker.Services.Models.CommentsModels
{
    public class GetAllCommentsRequestDto
    {
        public int TopicId { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
