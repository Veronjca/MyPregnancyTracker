using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.CommentsModels
{
    public class EditCommentDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
