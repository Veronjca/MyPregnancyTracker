using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models.CommentsModels;
using MyPregnancyTracker.Services.Models.ReactionsModels;
using SendGrid.Helpers.Errors.Model;

namespace MyPregnancyTracker.Services.Services.CommentsService
{
    public class CommentsService : ICommentsService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<Topic> _topicsResporitory;
        private readonly IRepository<Comment> _commentsRepository;
        private readonly IDataProtector _dataProtector;

        public CommentsService(IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            IRepository<Topic> topicsResporitory,
            IRepository<Comment> commentsRepository)
        {
            this._configuration = configuration;
            this._topicsResporitory = topicsResporitory;
            this._commentsRepository = commentsRepository;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }
        public async Task<List<CommentDto>> GetAllAsync(int topicId)
        {
            var topic = await this._topicsResporitory
                .GetAll()
                .Where(t => t.Id == topicId)
                .FirstOrDefaultAsync();

            if(topic == null)
            {
                throw new NotFoundException();
            }

            var comments = await this._commentsRepository
                .GetAll()
                .Include(c => c.Reactions)
                .Include(c => c.User)
                .Where(c => c.TopicId == topicId && c.DeletedOn == null)  
                .Select(c => new CommentDto
                {
                    Id = c.Id,
                    Content = c.Content,
                    CreatedOn = c.CreatedOn,
                    UserId = this._dataProtector.Protect(c.UserId.ToString()),
                    UserName = c.User.UserName,
                    Reactions = c.Reactions
                    .Select(r => new ReactionDto
                    {
                        Id = r.Id,
                        Type = r.ReactionType
                    })
                    .ToList()
                })
                .ToListAsync();

            return comments;
        }
    }
}
