namespace MyPregnancyTracker.Services.Models.AccountsModels
{
    public class GetUserProfileDataResponse
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? Weight { get; set; }

        public int? Height { get; set; }

        public DateTime DueDate { get; set; }
    }
}
