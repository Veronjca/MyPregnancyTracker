
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.ArticlesModels
{
    public class EditArticleRequestDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
