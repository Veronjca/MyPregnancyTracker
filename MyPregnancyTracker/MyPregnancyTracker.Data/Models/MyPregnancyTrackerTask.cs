using MyPregnancyTracker.Data.Models.Contracts;
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Data.Models
{
    public class MyPregnancyTrackerTask : IAuditInfo
    {
        public MyPregnancyTrackerTask()
        {
            this.ApplicationUsersMyPregnancyTrackerTasks = new HashSet<ApplicationUserMyPregnancyTrackerTask>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public ICollection<ApplicationUserMyPregnancyTrackerTask> ApplicationUsersMyPregnancyTrackerTasks { get; set; }

        public int GestationalWeekId { get; set; }

        public GestationalWeek GestationalWeek { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
