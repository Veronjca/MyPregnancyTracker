namespace MyPregnancyTracker.Data.Constants
{
    public static class ValidationConstants
    {
        public static class ApplicationUser
        {
            public const int GESTATIONAL_WEEK_MIN_VALUE = 1;

            public const int GESTATIONAL_WEEK_MAX_VALUE = 40;
        }
        
        public static class Comment
        {
            public const int COMMENT_CONTENT_MAX_LENGTH = 2000;
        }
        
        public static class GestationalWeek
        {
            public const int GESTATIONAL_AGE_MIN_VALUE = 1;

            public const int GESTATIONAL_AGE_MAX_VALUE = 40;
        }
       
        public static class Topic
        {
            public const int TOPIC_CONTENT_MAX_LENGTH = 2000;
        } 
    }
}
