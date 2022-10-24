using System.ComponentModel.DataAnnotations;
using static MyPregnancyTracker.Services.Constants.Constants.Validation;

namespace MyPregnancyTracker.Services.Models
{
    public class ResetPasswordDto
    {
        [Required]
        public string EncodedEmail { get; set; }

        [Required]
        [RegularExpression(PASSWORD_VALIDATION_PATTERN)]
        public string NewPassword { get; set; }

        [Required]
        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }

        [Required]
        public string EncodedToken { get; set; }
    }
}
