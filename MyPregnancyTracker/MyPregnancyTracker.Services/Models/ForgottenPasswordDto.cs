using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models
{
    public class ForgottenPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
