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

            public const string DELETE_ACCOUNT_ROUTE = "delete-account";
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

        public static class TopicsControllerRoutes
        {
            public const string TOPICS_ROUTE = "api/topics";

            public const string GET_ALL_TOPICS_ROUTE = "get-all";

            public const string GET_ONE_TOPIC_ROUTE = "get-one";

            public const string ADD_TOPIC_ROUTE = "add-topic";

            public const string GET_USER_TOPICS_ROUTE = "get-user-topics";

            public const string DELETE_TOPIC_ROUTE = "delete-topic";

            public const string EDIT_TOPIC_ROUTE = "edit-topic";

        }

        public static class CommentsControllerRoutes
        {
            public const string COMMENTS_ROUTE = "api/comments";

            public const string GET_ALL_COMMENTS_ROUTE = "get-all";

            public const string ADD_COMMENT_ROUTE = "add-comment";

            public const string DELETE_COMMENT_ROUTE = "delete-comment";

            public const string EDIT_COMMENT_ROUTE = "edit-comment";

            public const string GET_USER_COMMENTS_ROUTE = "get-user-comments";

        }

        public static class ReactionsControllerRoutes
        {
            public const string REACTIONS_ROUTE = "api/reactions";

            public const string ADD_REACTION_ROUTE = "add-reaction";

            public const string DELETE_REACTION_ROUTE = "delete-reaction";

            public const string GET_USER_REACTIONS_ROUTE = "get-user-reactions";
        }

        public static class ArticlesControllerRoutes
        {
            public const string ARTICLES_ROUTE = "api/articles";

            public const string GET_ALL_ARTICLES_ROUTE = "get-all";

            public const string DELETE_ARTICLE_ROUTE = "delete-article";

            public const string EDIT_ARTICLE_ROUTE = "edit-article";

            public const string ADD_REACTION_ROUTE = "add-reaction";

            public const string ADD_ARTICLE_ROUTE = "add-article";

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
