using MyPregnancyTracker.Services.Models.CommentsModels;

namespace MyPregnancyTracker.Services.Models.ReactionsModels
{
    public class AddDeleteReactionResponseDto
    {
        public List<ReactionDto> UserReactions { get; set; }

        public GetAllCommentsResponseDto TopicComments { get; set; }
    }
}
