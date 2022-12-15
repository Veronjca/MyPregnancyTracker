namespace MyPregnancyTracker.Services.Models.AccountsModels
{
    public class LoginResponseDto
    {
        public string Id { get; set; }

        public int GestationalWeekAge { get; set; }

        public string UserName { get; set; } 

        public string Email { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
