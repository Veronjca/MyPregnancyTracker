
using MyPregnancyTracker.Services.Models.ReactionsModels;

namespace MyPregnancyTracker.Services.Models.CommentsModels
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public List<ReactionDto> Reactions { get; set; }
    }
}
