
namespace MyPregnancyTracker.Services.Models.ArticlesModels
{
    public class GetAllArticlesResponseDto
    {
        public ICollection<ArticleDto> Articles { get; set; }

        public int ArticlesCount { get; set; }
    }
}
