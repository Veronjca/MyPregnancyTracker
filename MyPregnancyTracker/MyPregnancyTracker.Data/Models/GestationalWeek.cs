using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Data.Models
{
    public class GestationalWeek
    {
        public GestationalWeek()
        {
            this.MyPregnancyTrackerTasks = new HashSet<MyPregnancyTrackerTask>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int GestationalAge { get; set; }

        [Required]
        public string MotherContent { get; set; }

        [Required]
        public string BabyContent { get; set; }

        [Required]
        public string NutritionContent { get; set; }

        [Required]
        public string AdvicesContent { get; set; }

        public ICollection<MyPregnancyTrackerTask> MyPregnancyTrackerTasks { get; set; }

    }
}
