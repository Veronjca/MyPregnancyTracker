using MyPregnancyTracker.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Data.Models
{
    public class Reaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ReactionTypeEnum ReactionType { get; set; }

        public bool IsDeleted { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int CommentId { get; set; }

        public Comment Comment { get; set; }
    }
}
