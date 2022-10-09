using System.ComponentModel.DataAnnotations;
using static MyPregnancyTracker.Services.Constants.Constants.Validation;

namespace MyPregnancyTracker.Services.Models
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(PASSWORD_VALIDATION_PATTERN)]
        public string Password { get; set; }
    }
}
