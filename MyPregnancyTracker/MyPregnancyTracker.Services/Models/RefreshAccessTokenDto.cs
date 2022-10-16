namespace MyPregnancyTracker.Services.Models
{
    public class RefreshAccessTokenDto
    {
        public string UserEmail { get; set; }
        public string RefreshToken { get; set; }
    }
}
