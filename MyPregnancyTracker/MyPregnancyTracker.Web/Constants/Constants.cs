namespace MyPregnancyTracker.Web.Constants
{
    public static class Constants
    {
        public static class Validation
        {
            public const int PASSWORD_MIN_LENGTH = 8;
        }

        public static class AccountsControllerRoutes
        {         
            public const string ACCOUNTS_ROUTE = "api/accounts";

            public const string LOGIN_ROUTE = "login";

            public const string REGISTER_ROUTE = "register";

            public const string CONFIRM_EMAIL_ROUTE = "confirm-email";

            public const string RESEND_CONFIRMATION_EMAIL_ROUTE = "resend-confirmation-email";

            public const string RESET_PASSWORD_ROUTE = "reset-password";

            public const string REFRESH_ACCESS_TOKEN_ROUTE = "refresh-access-token";

            public const string SEND_RESET_PASSWORD_EMAIL_ROUTE = "send-reset-password-email";
        }

        public static class TasksControllerRoutes
        {
            public const string TASKS_ROUTE = "api/tasks";

            public const string GET_ALL_TASKS_ROUTE = "get-all-tasks";
        }

        public static class UserControllerRoutes
        {
            public const string USER_ROUTE = "api/user";

            public const string UPDATE_USER_PROFILE_ROUTE = "update-user-profile";

            public const string GET_USER_PROFILE_DATA_ROUTE = "get-user-profile-data";

            public const string SET_GESTATIONAL_WEEK_ROUTE = "set-gestational-week";

            public const string ADD_TASK_ROUTE = "add-task";

            public const string REMOVE_TASK_ROUTE = "remove-task";
        }

        public static class GestationalWeekControllerRoutes
        {
            public const string GESTATIONAL_WEEK_ROUTE = "api/gestational-week";

            public const string GET_ALL = "get-all";

            public const string GET_ONE = "get-one";
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
