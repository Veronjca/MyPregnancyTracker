
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.ArticlesModels
{
    public class AddReactionToArticleRequestDto
    {
        public bool? IsLiked { get; set; }

        [Required]
        public int ArticleId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
