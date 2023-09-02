
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyPregnancyTracker.Data.Enums;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models.CommentsModels;
using MyPregnancyTracker.Services.Models.ReactionsModels;
using MyPregnancyTracker.Services.Services.CommentsService;
using SendGrid.Helpers.Errors.Model;

namespace MyPregnancyTracker.Services.Services.ReactionsService
{
    public class ReactionsService : IReactionsService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Reaction> _reactionRepository;
        private readonly ICommentsService _commentsService;
        private readonly IDataProtector _dataProtector; 

        public ReactionsService(UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            IRepository<Comment> commentRepository,
            IRepository<Reaction> reactionRepository,
            ICommentsService commentsService) 
        {
            this._userManager = userManager;
            this._configuration = configuration;
            this._commentRepository = commentRepository;
            this._reactionRepository = reactionRepository;
            this._commentsService = commentsService;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }
        public async Task<AddDeleteReactionResponseDto> AddToCommentAsync(AddDeleteReactionRequestDto addDeleteReactionRequest)
        {
            var unprotectedUserId = this._dataProtector.Unprotect(addDeleteReactionRequest.UserId);
            var user = await this._userManager.FindByIdAsync(unprotectedUserId);

            if(user == null)
            {
                throw new NotFoundException();
            }

            var comment = await this._commentRepository
                .GetAll()
                .Where(c => c.Id == addDeleteReactionRequest.CommentId)
                .FirstOrDefaultAsync();

            if(comment == null)
            {
                throw new NotFoundException();
            }

            var reaction = new Reaction
            {
                CommentId = addDeleteReactionRequest.CommentId,
                UserId = int.Parse(unprotectedUserId),
                ReactionType = Enum.Parse<ReactionTypeEnum>(addDeleteReactionRequest.ReactionType)
            };

            await this._reactionRepository.AddAsync(reaction);
            await this._reactionRepository.SaveChangesAsync();

            var userReactions = await this.GetUserReactionsAsync(addDeleteReactionRequest.UserId);

            var model = new GetAllCommentsRequestDto
            {
                TopicId = addDeleteReactionRequest.TopicId,
                Skip = addDeleteReactionRequest.Skip,
                Take = addDeleteReactionRequest.Take
            };

            var topicComments = await this._commentsService.GetAllAsync(model);


            return new AddDeleteReactionResponseDto
            {
                TopicComments = topicComments,
                UserReactions = userReactions
            };
        }

        public async Task<AddDeleteReactionResponseDto> DeleteFromCommentAsync(AddDeleteReactionRequestDto addDeleteReactionRequest)
        {
            var unprotectedUserId = this._dataProtector.Unprotect(addDeleteReactionRequest.UserId);
            var user = await this._userManager.FindByIdAsync(unprotectedUserId);
            var reactionTypeEnum = Enum.Parse<ReactionTypeEnum>(addDeleteReactionRequest.ReactionType);

            if(user == null)
            {
                throw new NotFoundException();
            }

            var comment = await this._commentRepository
                .GetAll()
                .Where(c => c.Id == addDeleteReactionRequest.CommentId)
                .FirstOrDefaultAsync();

            if(comment == null)
            {
                throw new NotFoundException();
            }

            var reaction = await this._reactionRepository
                .GetAll()
                .Where(r => r.ReactionType == reactionTypeEnum && r.IsDeleted == false && r.CommentId == addDeleteReactionRequest.CommentId && r.UserId == int.Parse(unprotectedUserId))
                .FirstOrDefaultAsync();

            if(reaction == null)
            {
                throw new NotFoundException();
            }

            reaction.IsDeleted = true;
            this._reactionRepository.Update(reaction);
            await this._reactionRepository.SaveChangesAsync();

            var userReactions = await this.GetUserReactionsAsync(addDeleteReactionRequest.UserId);

            var model = new GetAllCommentsRequestDto
            {
                TopicId = addDeleteReactionRequest.TopicId,
                Skip = addDeleteReactionRequest.Skip,
                Take = addDeleteReactionRequest.Take
            };
            var topicComments = await this._commentsService.GetAllAsync(model);

            return new AddDeleteReactionResponseDto
            {
                TopicComments = topicComments,
                UserReactions = userReactions
            };
        }

        public async Task<List<ReactionDto>> GetUserReactionsAsync(string userId)
        {
            var unprotectedUserId = this._dataProtector.Unprotect(userId);
            var user = await this._userManager.FindByIdAsync(unprotectedUserId);

            if(user == null)
            {
                throw new NotFoundException();
            }

            var reactions = await this._reactionRepository
                .GetAll()
                .Where(r => r.UserId == int.Parse(unprotectedUserId) && r.IsDeleted == false)
                .Select(r => new ReactionDto
                {
                    Type = r.ReactionType.ToString(),
                    CommentId = r.CommentId
                })
                .ToListAsync();

            return reactions;
        }
    }
}
