using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models
{
    public class ResetPasswordEmailDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
