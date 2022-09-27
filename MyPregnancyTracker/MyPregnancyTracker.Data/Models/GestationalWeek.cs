using static MyPregnancyTracker.Data.Constants.ValidationConstants;
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Data.Models
{
    public class GestationalWeek
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(GESTATIONAL_AGE_MIN_VALUE, GESTATIONAL_AGE_MAX_VALUE)]
        public int GestationalAge { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public string MotherPictureUrl { get; set; }

        [Required]
        public string MotherContent { get; set; }

        [Required]
        public string BabyPictureUrl { get; set; }

        [Required]
        public string BabyContent { get; set; }

        [Required]
        public string NutritionPictureUrl { get; set; }

        [Required]
        public string NutritionContent { get; set; }

        [Required]
        public string AdvicesPictureUrl { get; set; }

        [Required]
        public string AdvicesContent { get; set; }

        [Required]
        public string TasksPictureUrl { get; set; }

        [Required]
        public string TasksContent { get; set; }
    }
}
