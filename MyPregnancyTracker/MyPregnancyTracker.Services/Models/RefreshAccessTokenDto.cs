using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models
{
    public class RefreshAccessTokenDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
