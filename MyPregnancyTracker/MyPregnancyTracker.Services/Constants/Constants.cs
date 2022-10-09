namespace MyPregnancyTracker.Services.Constants
{
    internal class Constants
    {
        public static class Validation
        {
            public const string PASSWORD_VALIDATION_PATTERN = @"^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\\d]){1,})(?=(.*[\\W]){1,})(?!.*\\s).{8,}$";
        }

        public static class Erorr
        {
            public const string USER_NOT_FOUND = "User not found!";

            public const string EMAIL_NOT_CONFIRMED = "Email not confirmed!";

            public const string INCORRECT_PASSWORD = "Invalid credentials!";
        }
    }
}
