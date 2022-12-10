
using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.TopicsModels
{
    public class GetAllTopicsRequestDto
    {
        [Required]
        public int Category { get; set; }

        [Required]
        public bool IsDescendingOrder { get; set; }

        [Required]
        public int Skip { get; set; }

        [Required]
        public int Take { get; set; }
    }
}
