using Microsoft.Extensions.DependencyInjection;
using MyPregnancyTracker.Services.Services.AccountService;
using MyPregnancyTracker.Services.Services.ArticlesService;
using MyPregnancyTracker.Services.Services.CommentsService;
using MyPregnancyTracker.Services.Services.EmailService;
using MyPregnancyTracker.Services.Services.GestationalWeekService;
using MyPregnancyTracker.Services.Services.ReactionsService;
using MyPregnancyTracker.Services.Services.TasksService;
using MyPregnancyTracker.Services.Services.TopicsService;
using MyPregnancyTracker.Services.Services.UserService;

namespace MyPregnancyTracker.Services
{
    public static class ServicesConfiguration
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<ITasksService, TasksService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IGestationalWeekService, GestationalWeekService>();

            services.AddScoped<ITopicsService, TopicsService>();

            services.AddScoped<ICommentsService, CommentsService>();

            services.AddScoped<IReactionsService, ReactionsService>();

            services.AddScoped<IArticlesService, ArticlesService>();
        }
    }
}
