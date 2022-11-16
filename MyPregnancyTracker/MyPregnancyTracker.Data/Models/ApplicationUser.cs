using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using MyPregnancyTracker.Data.Models.Contracts;

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
            this.ApplicationUsersMyPregnancyTrackerTasks = new HashSet<ApplicationUserMyPregnancyTrackerTask>();
        }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        public DateTime FirstDayOfLastMenstruation { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        [Required]
        public int GestationalWeek { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<int>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }

        public virtual ICollection<ApplicationUserMyPregnancyTrackerTask> ApplicationUsersMyPregnancyTrackerTasks { get; set; }

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
