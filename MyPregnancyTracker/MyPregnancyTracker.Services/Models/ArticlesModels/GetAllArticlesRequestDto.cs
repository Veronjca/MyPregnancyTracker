using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.ArticlesModels
{
    public class GetAllArticlesRequestDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int Skip { get; set; }

        [Required]
        public int Take { get; set; }
    }
}
