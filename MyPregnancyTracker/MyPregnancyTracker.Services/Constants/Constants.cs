namespace MyPregnancyTracker.Services.Constants
{
    internal class Constants
    {
        public static class Validation
        {
            public const string PASSWORD_VALIDATION_PATTERN = @"^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,}$";
        }

        public static class Error
        {
            public const string USER_NOT_FOUND = "User not found!";

            public const string EMAIL_NOT_CONFIRMED = "Email not confirmed!";

            public const string INCORRECT_PASSWORD = "Invalid credentials!";

            public const string PASSWORDS_DONT_MATCH = "Passwords don't match!";

            public const string MISSING_SUBJECT_AND_MESSAGE = "Subject and message should be provided.";

            public const string SESSION_EXPIRED = "Session expired!";
        }

        public static class Common
        {
            public const string CONFIRMATION_EMAIL_HTML_TEMPLATE_FILE_NAME = "EmailConfirmationTemplate.html";
        }

        public static class Email
        {
            public const string FROM = "mypregnancytrackerapp@gmail.com";

            public const string FROM_NAME = "My Pregnancy Tracker";

            public const string SUBJECT = "Verify your email";
        }
    }
}
