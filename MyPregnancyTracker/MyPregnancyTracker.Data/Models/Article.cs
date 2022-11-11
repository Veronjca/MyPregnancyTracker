using System.ComponentModel.DataAnnotations;
using MyPregnancyTracker.Data.Models.Contracts;

namespace MyPregnancyTracker.Data.Models
{
    public class Article : IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
