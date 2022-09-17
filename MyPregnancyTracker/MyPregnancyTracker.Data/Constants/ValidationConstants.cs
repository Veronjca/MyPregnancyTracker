namespace MyPregnancyTracker.Data.Constants
{
    public static class ValidationConstants
    {
        public const string PASSWORD_VALIDATION_PATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,20}$";

        public const int GESTATIONAL_WEEK_MIN_VALUE = 1;

        public const int GESTATIONAL_WEEK_MAX_VALUE = 40;

        public const int GESTATIONAL_AGE_MIN_VALUE = 1;

        public const int GESTATIONAL_AGE_MAX_VALUE = 40;

        public const int TOPIC_CONTENT_MAX_LENGTH = 2000;

        public const int COMMENT_CONTENT_MAX_LENGTH = 2000;       
    }
}
