using Microsoft.AspNetCore.Identity;
using static MyPregnancyTracker.Data.Constants.ValidationConstants.ApplicationUser;
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Data.Models
{
    public class ApplicationUser : IdentityUser<int>, IAuditInfo
    {
        public ApplicationUser()
        {
            this.Topics = new HashSet<Topic>();
            this.Comments = new HashSet<Comment>();
            this.Reactions = new HashSet<Reaction>();
            this.Roles = new HashSet<IdentityUserRole<int>>();
            this.Claims = new HashSet<IdentityUserClaim<int>>();
            this.Logins = new HashSet<IdentityUserLogin<int>>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime FirstDayOfLastMenstruation { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        [Range(GESTATIONAL_WEEK_MIN_VALUE, GESTATIONAL_WEEK_MAX_VALUE)]
        public int GestationalWeek { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<int>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }

        public int CommentId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public int TopicId { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public int ReactionId { get; set; }

        public virtual ICollection<Reaction> Reactions { get; set; }

        public string? AccessToken { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpirationDate { get; set; }
    }
}
