using Microsoft.Extensions.DependencyInjection;
using MyPregnancyTracker.Services.Services.AccountService;

namespace MyPregnancyTracker.Services
{
    public static class ServicesConfiguration
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
