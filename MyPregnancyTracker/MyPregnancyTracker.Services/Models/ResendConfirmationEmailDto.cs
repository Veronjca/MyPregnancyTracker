using System.ComponentModel.DataAnnotations;

namespace MyPregnancyTracker.Services.Models
{
    public class ResendConfirmationEmailDto
    {
        [Required]
        public string Email { get; set; }  
    }
}
