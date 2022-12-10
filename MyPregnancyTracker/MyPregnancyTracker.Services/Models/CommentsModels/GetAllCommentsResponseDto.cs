
namespace MyPregnancyTracker.Services.Models.CommentsModels
{
    public class GetAllCommentsResponseDto
    {
        public List<CommentDto> Comments { get; set; }

        public int CommentsCount { get; set; }
    }
}
