
namespace MyPregnancyTracker.Services.Models.ArticlesModels
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public bool? IsLiked { get; set; }
    }
}
