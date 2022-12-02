using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDataProtector _dataProtector;

        public CommentsService(IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            IRepository<Topic> topicsResporitory,
            IRepository<Comment> commentsRepository,
            UserManager<ApplicationUser> userManager)
        {
            this._configuration = configuration;
            this._topicsResporitory = topicsResporitory;
            this._commentsRepository = commentsRepository;
            this._userManager = userManager;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }

        public async Task<bool> AddAsync(AddCommentRequestDto addCommentRequestDto)
        {
            var unprotectedUserId = this._dataProtector.Unprotect(addCommentRequestDto.UserId);
            var user = await this._userManager.FindByIdAsync(unprotectedUserId);

            if(user == null)
            {
                return false;
            }

            var topic = await this._topicsResporitory
                .GetAll()
                .Where(t => t.Id == addCommentRequestDto.TopicId && !t.DeletedOn.HasValue)
                .FirstOrDefaultAsync();

            if(topic == null)
            {
                return false;
            }

            var comment = new Comment
            {
                UserId = int.Parse(unprotectedUserId),
                TopicId = addCommentRequestDto.TopicId,
                Content = addCommentRequestDto.Content
            };

           await this._commentsRepository.AddAsync(comment);
           await this._commentsRepository.SaveChangesAsync();
           return true;
        }

        public async Task<bool> DeleteAsync(int commentId, string userId)
        {
            var unprotectedUserId = int.Parse(this._dataProtector.Unprotect(userId));

            var comment = await this._commentsRepository
                .GetAll()
                .Where(c => c.Id == commentId && c.UserId == unprotectedUserId)
                .FirstOrDefaultAsync();

            if(comment == null)
            {
                return false;
            }

            comment.DeletedOn = DateTime.UtcNow;
            await this._commentsRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditAsync(EditCommentDto commentDto)
        {
            var unprotectedUserId = int.Parse(this._dataProtector.Unprotect(commentDto.UserId));

            var comment = await this._commentsRepository
                .GetAll()
                .Where(c => c.Id == commentDto.Id && !c.DeletedOn.HasValue && c.UserId == unprotectedUserId)
                .FirstOrDefaultAsync();

            if(comment == null)
            {
                return false;
            }

            comment.Content = commentDto.Content;
            this._commentsRepository.Update(comment);
            await this._commentsRepository.SaveChangesAsync();

            return true;
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
                .Where(c => c.TopicId == topicId && !c.DeletedOn.HasValue)  
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

        public async Task<List<CommentDto>> GetUserCommentsAsync(string userId, int topicId)
        {
            var unprotectedUserId = int.Parse(this._dataProtector.Unprotect(userId));
            var user = await this._userManager.FindByIdAsync(unprotectedUserId.ToString());

            if(user == null)
            {
                throw new NotFoundException();
            }

            var topic = await this._topicsResporitory
                .GetAll()
                .Where(t => t.Id == topicId && !t.DeletedOn.HasValue && t.UserId == unprotectedUserId)
                .FirstOrDefaultAsync();

            if(topic == null)
            {
                throw new NotFoundException();
            }

            var comments = await this._commentsRepository
                .GetAll()
                .Include(c => c.Reactions)
                .Include(c => c.User)
                .Where(c => c.UserId == unprotectedUserId && !c.DeletedOn.HasValue && c.TopicId == topicId)
                .Select(c => new CommentDto
                {
                    Content = c.Content,
                    CreatedOn = c.CreatedOn,    
                    Id = c.Id,
                    Reactions = c.Reactions
                    .Select(r => new ReactionDto
                    {
                        Id = r.Id,
                        Type = r.ReactionType
                    })
                    .ToList(),
                    UserId = this._dataProtector.Protect(c.UserId.ToString()),
                    UserName = c.User.UserName                    
                })
                .ToListAsync();

            return comments;
        }
    }
}
