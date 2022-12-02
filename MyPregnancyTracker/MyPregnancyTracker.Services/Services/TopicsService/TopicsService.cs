using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
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

            if (user == null)
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
                        .Include(t => t.User)
                        .Where(t => (int)t.TopicCategory == category && !t.DeletedOn.HasValue)
                        .Select(t => new TopicDto
                        {
                            Id = t.Id.ToString(),
                            Content = t.Content,
                            Title = t.Title,
                            UserId = this._dataProtector.Protect(t.UserId.ToString()),
                            UserName = t.User.UserName,
                            CreatedOn = t.CreatedOn,
                            Category = t.TopicCategory
                        })
                        .ToListAsync();

            return topics;
        }

        public async Task<TopicDto> GetOneAsync(int topicId)
        {
            var topic = await this._topicsRepository.GetAll()
                       .Include(t => t.User)
                       .Where(t => t.Id == topicId && !t.DeletedOn.HasValue)
                       .Select(t => new TopicDto
                       {
                           Id = t.Id.ToString(),
                           Content = t.Content,
                           Title = t.Title,
                           CreatedOn = t.CreatedOn,
                           UserId = this._dataProtector.Protect(t.UserId.ToString()),
                           UserName = t.User.UserName,
                           Category = t.TopicCategory
                       })
                       .FirstAsync();

            return topic;
        }

        public async Task<List<TopicDto>> GetUserTopicsAsync(string userId)
        {
            var unprotectedUserId = int.Parse(this._dataProtector.Unprotect(userId));
            var user = await this._userManager.FindByIdAsync(unprotectedUserId.ToString());

            if(user == null)
            {
                throw new NotFoundException();
            }

            var topics = await this._topicsRepository.GetAll()
                       .Include(t => t.User)
                       .Where(t => t.UserId == unprotectedUserId && !t.DeletedOn.HasValue)
                       .Select(t => new TopicDto
                       {
                           Id = t.Id.ToString(),
                           Content = t.Content,
                           Title = t.Title,
                           CreatedOn = t.CreatedOn,
                           UserId = this._dataProtector.Protect(t.UserId.ToString()),
                           UserName = t.User.UserName,
                           Category = t.TopicCategory
                       })
                       .ToListAsync();

            return topics;
        }

        public async Task<bool> DeleteTopicAsync(int topicId, string userId)
        {
            var unprotectedUserId = int.Parse(this._dataProtector.Unprotect(userId));

            var topic = await this._topicsRepository
                .GetAll()
                .Where(t => t.Id == topicId && t.UserId == unprotectedUserId)
                .FirstOrDefaultAsync();

            if(topic == null)
            {
                return false;
            }

            topic.DeletedOn = DateTime.UtcNow;
            await this._topicsRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditTopicAsync(TopicDto topicDto)   
        {
            var unprotectedUserId = int.Parse(this._dataProtector.Unprotect(topicDto.UserId));

            var topic = await this._topicsRepository
                .GetAll()
                .Where(t => t.Id == int.Parse(topicDto.Id) && !t.DeletedOn.HasValue && t.UserId == unprotectedUserId)
                .FirstOrDefaultAsync();

            if(topic == null)
            {
                return false;
            }

            topic.Content = topicDto.Content;
            this._topicsRepository.Update(topic);
            await this._topicsRepository.SaveChangesAsync();

            return true;
        }
    }
}
