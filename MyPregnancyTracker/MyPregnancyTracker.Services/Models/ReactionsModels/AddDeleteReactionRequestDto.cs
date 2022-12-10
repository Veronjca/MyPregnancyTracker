using MyPregnancyTracker.Services.Models.CommentsModels;

namespace MyPregnancyTracker.Services.Models.ReactionsModels
{
    public class AddDeleteReactionRequestDto : GetAllCommentsRequestDto
    {
        public string ReactionType { get; set; }

        public int CommentId { get; set; }

        public string UserId { get; set; }
    }
}
