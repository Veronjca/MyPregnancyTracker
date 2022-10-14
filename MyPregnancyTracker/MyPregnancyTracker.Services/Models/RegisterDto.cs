using System.ComponentModel.DataAnnotations;
using static MyPregnancyTracker.Services.Constants.Constants.Validation;
using static MyPregnancyTracker.Services.Constants.Constants.Erorr;

namespace MyPregnancyTracker.Services.Models
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(PASSWORD_VALIDATION_PATTERN)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = PASSWORDS_DONT_MATCH)]
        public string ConfirmPassword { get; set; }

        [Required]
        public DateTime FirstDayOfLastMenstruation { get; set; }
    }
}
