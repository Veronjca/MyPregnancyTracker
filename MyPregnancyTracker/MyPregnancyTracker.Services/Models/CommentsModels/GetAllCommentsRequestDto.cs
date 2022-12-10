using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.CommentsModels
{
    public class GetAllCommentsRequestDto
    {
        [Required]
        public int TopicId { get; set; }

        [Required]
        public int Skip { get; set; }

        [Required]
        public int Take { get; set; }
    }
}
