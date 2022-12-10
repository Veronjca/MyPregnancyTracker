using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.AccountsModels
{
    public class ResetPasswordEmailDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
