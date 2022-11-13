using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.AccountsModels
{
    public class ResendConfirmationEmailDto
    {
        [Required]
        public string Email { get; set; }
    }
}
