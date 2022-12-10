
namespace MyPregnancyTracker.Data.Models
{
    public class UserArticle
    {
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public int ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public bool? IsLiked { get; set; }
    }
}
