using MyPregnancyTracker.Data.Constants;
using MyPregnancyTracker.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Data.Models
{
    public class Topic
    {
        public Topic()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public TopicCategoryEnum TopicCategory { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TOPIC_CONTENT_MAX_LENGTH)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeleteOn { get; set; }

        public int CommentId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
