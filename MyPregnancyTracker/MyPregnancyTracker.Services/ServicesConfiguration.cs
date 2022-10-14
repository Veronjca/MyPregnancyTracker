using Microsoft.Extensions.DependencyInjection;
using MyPregnancyTracker.Services.Services.AccountService;
using MyPregnancyTracker.Services.Services.EmailService;

namespace MyPregnancyTracker.Services
{
    public static class ServicesConfiguration
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
