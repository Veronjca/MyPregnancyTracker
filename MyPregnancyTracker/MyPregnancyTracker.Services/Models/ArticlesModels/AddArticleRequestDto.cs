
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.ArticlesModels
{
    public class AddArticleRequestDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
