using MyPregnancyTracker.Services.Models.CommentsModels;
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.ReactionsModels
{
    public class AddDeleteReactionRequestDto : GetAllCommentsRequestDto
    {
        [Required]
        public string ReactionType { get; set; }

        [Required]
        public int CommentId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
