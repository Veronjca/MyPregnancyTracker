using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.AccountsModels
{
    public class ConfirmEmailDto
    {
        [Required]
        public string EmailToken { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
