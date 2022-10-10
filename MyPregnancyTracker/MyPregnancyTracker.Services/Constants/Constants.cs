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

            public const string PASSWORDS_DONT_MATCH = "Passwords don't match!";

            public const string MISSING_SUBJECT_AND_MESSAGE = "Subject and message should be provided.";
        }
    }
}
