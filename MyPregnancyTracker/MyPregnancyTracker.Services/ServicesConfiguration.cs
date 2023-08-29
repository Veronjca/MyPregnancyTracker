using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.EmailSender;
using MyPregnancyTracker.Services.Services.AccountService;
using MyPregnancyTracker.Services.Services.ArticlesService;
using MyPregnancyTracker.Services.Services.CommentsService;
using MyPregnancyTracker.Services.Services.EmailService;
using MyPregnancyTracker.Services.Services.GestationalWeekService;
using MyPregnancyTracker.Services.Services.ReactionsService;
using MyPregnancyTracker.Services.Services.TasksService;
using MyPregnancyTracker.Services.Services.TopicsService;
using MyPregnancyTracker.Services.Services.UserService;
using Nest;

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

        public static void AddElasticsearch(this IServiceCollection services, ConfigurationManager configuration)
        {
            var accessKey = configuration["BonsaiAccessKey"];
            var accessSecret = configuration["BonsaiAccessSecretKey"];
            var bonsaiEndpoint = configuration["BonsaiEndpoint"];

            var settings = new ConnectionSettings(new Uri(bonsaiEndpoint))
                .ApiKeyAuthentication(accessKey, accessSecret);

            services.AddSingleton<IConnectionConfigurationValues>(settings);
            services.AddSingleton<IElasticLowLevelClient, ElasticLowLevelClient>(); 
        }

        public static void AddEmailSender(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient<IEmailSender>(options => new SendGridEmailSender(configuration["SendGridApiKey"]));
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(MyPregnancyTracker.Data.Repositories.IRepository<>), typeof(EfRepository<>));
        }
    }
}
