using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models.AccountsModels
{
    public class RefreshAccessTokenDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
