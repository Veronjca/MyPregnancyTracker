using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyPregnancyTracker.Data.Enums;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models.TopicsModels;
using SendGrid.Helpers.Errors.Model;

namespace MyPregnancyTracker.Services.Services.TopicsService
{
    public class TopicsService : ITopicsService
    {
        private readonly IRepository<Topic> _topicsRepository;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDataProtector _dataProtector;

        public TopicsService(IRepository<Topic> topicsRepository,
            IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            UserManager<ApplicationUser> userManager)
        {
            this._topicsRepository = topicsRepository;
            this._configuration = configuration;
            this._userManager = userManager;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }

        public async Task<bool> AddTopicAsync(AddTopicDto addTopicDto)
        {
            var userId = this._dataProtector.Unprotect(addTopicDto.UserId);
            var user = await this._userManager.FindByIdAsync(userId);

            if(user == null)
            {
                return false;
            }

            var topic = new Topic
            {
                Title = addTopicDto.Title,
                UserId = int.Parse(userId),
                Content = addTopicDto.Content,
                TopicCategory = addTopicDto.Category
            };

            await this._topicsRepository.AddAsync(topic);
            await this._topicsRepository.SaveChangesAsync();

            return true;
        }

        public async Task<List<TopicDto>> GetAllAsync(int category)
        {
            var topics = await this._topicsRepository
                        .GetAll()
                        .Where(t => (int)t.TopicCategory == category)
                        .Select(t => new TopicDto
                        {
                            Id = this._dataProtector.Protect(t.Id.ToString()),
                            Content = t.Content,
                            Title = t.Title,
                            UserId = this._dataProtector.Protect(t.UserId.ToString()),
                        })
                        .ToListAsync();

            return topics;
        }
    }
}
