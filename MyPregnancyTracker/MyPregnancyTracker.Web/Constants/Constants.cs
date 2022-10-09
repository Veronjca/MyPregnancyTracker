namespace MyPregnancyTracker.Web.Constants
{
    public static class Constants
    {
        public static class Validation
        {
            public const int PASSWORD_MIN_LENGTH = 8;
        }

        public static class Route
        {
            public const string ACCOUNTS_ROUTE = "api/accounts";

            public const string LOGIN_ROUTE = "login";
        }

        public static class Error
        {
            public static string INVALID_LOGIN = "Invalid credentials!";
        }
    }
}
