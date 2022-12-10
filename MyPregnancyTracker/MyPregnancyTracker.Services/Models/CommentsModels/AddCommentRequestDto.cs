using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.CommentsModels
{
    public class AddCommentRequestDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
