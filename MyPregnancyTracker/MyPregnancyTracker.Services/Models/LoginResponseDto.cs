﻿namespace MyPregnancyTracker.Services.Models
{
    public class LoginResponseDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
