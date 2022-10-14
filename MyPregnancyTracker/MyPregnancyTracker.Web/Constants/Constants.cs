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

            public const string REGISTER_ROUTE = "register";

            public const string CONFIRM_EMAIL_ROUTE = "confirm-email";
        }

        public static class Error
        {
            public const string INVALID_LOGIN = "Invalid credentials!";

            public const string INVALID_REGISTER = "Invalid credentials!";
        }

        public static class Swagger
        {
            public const string SWAGGER_ENDPOINT = "/swagger/v1/swagger.json";

            public const string SWAGGER_VERSION = "v1";
        }
    }
}
