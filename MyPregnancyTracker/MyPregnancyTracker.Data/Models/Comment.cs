using static MyPregnancyTracker.Data.Constants.ValidationConstants.Comment;
using System.ComponentModel.DataAnnotations;
using MyPregnancyTracker.Data.Models.Contracts;

namespace MyPregnancyTracker.Data.Models
{
    public class Comment : IAuditInfo
    {
        public Comment()
        {
            this.Reactions = new HashSet<Reaction>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(COMMENT_CONTENT_MAX_LENGTH)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int TopicId { get; set; }

        public Topic Topic { get; set; }

        public int ReactionId { get; set; }

        public virtual ICollection<Reaction> Reactions { get; set; }
    }
}
