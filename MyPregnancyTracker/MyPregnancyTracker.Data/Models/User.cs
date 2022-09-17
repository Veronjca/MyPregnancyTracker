using MyPregnancyTracker.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Data.Models
{
    public class User
    {
        public User()
        {
            this.Topics = new HashSet<Topic>();
            this.Comments = new HashSet<Comment>();
            this.Reactions = new HashSet<Reaction>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.PASSWORD_VALIDATION_PATTERN)]
        public string Password { get; set; }

        [Required]
        public DateTime FirstDayOfLastMenstruation { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        [Range(ValidationConstants.GESTATIONAL_WEEK_MIN_VALUE, ValidationConstants.GESTATIONAL_WEEK_MAX_VALUE)]
        public int GestationalWeek { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int CommentId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public int TopicId { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public int ReactionId { get; set; }

        public virtual ICollection<Reaction> Reactions { get; set; }
    }
}
