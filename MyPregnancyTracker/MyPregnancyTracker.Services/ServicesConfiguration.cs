using Microsoft.Extensions.DependencyInjection;
using MyPregnancyTracker.Services.Services.AccountService;
using MyPregnancyTracker.Services.Services.EmailService;
using MyPregnancyTracker.Services.Services.TasksService;
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
        }
    }
}
