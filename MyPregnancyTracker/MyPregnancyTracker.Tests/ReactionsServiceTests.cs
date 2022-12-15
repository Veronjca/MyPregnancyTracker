
using MyPregnancyTracker.Data.Enums;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.ReactionsModels;
using MyPregnancyTracker.Services.Services.CommentsService;
using MyPregnancyTracker.Services.Services.ReactionsService;

namespace MyPregnancyTracker.Tests
{
    public class ReactionsServiceTests : SetUp
    {
        ICommentsService _commentsService;
        IReactionsService _reactionsService;

        [SetUp]
        public async Task SetUp()
        {
            await InitializeDatabase();

            var userManager = GetUserManager();
            var configuration = GetIConfiguration();
            var dataProtector = GetProtectionProvider();
            var commentsRepository = GetCommentsRepository();
            var reactionsRepository = GetReactionsRepository();
            var topicsRepository = GetTopicsRepository();

            this._commentsService = new CommentsService(configuration, dataProtector, topicsRepository, commentsRepository, userManager);
            this._reactionsService = new ReactionsService(userManager, configuration, dataProtector, commentsRepository, reactionsRepository, this._commentsService);
        }

        [Test]
        public async Task AddShouldWorkProperly()
        {
            var addDeleteReactionRequest = new AddDeleteReactionRequestDto
            {
                CommentId = 1,
                ReactionType = ReactionTypeEnum.Like.ToString(),
                Skip = 0,
                Take = 1,
                TopicId = 1,
                UserId = MOCK_USER_ID
            };

            var expectedReactionCount = context.Set<Reaction>()
                .Where(r => r.CommentId == addDeleteReactionRequest.CommentId && r.UserId == 1 && r.ReactionType == Enum.Parse<ReactionTypeEnum>(addDeleteReactionRequest.ReactionType))
                .Count() + 1;

            var result = await this._reactionsService.AddAsync(addDeleteReactionRequest);

            var actualReactionCount = context.Set<Reaction>()
                .Where(r => r.CommentId == addDeleteReactionRequest.CommentId && r.UserId == 1 && r.ReactionType == Enum.Parse<ReactionTypeEnum>(addDeleteReactionRequest.ReactionType))
                .Count();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.UserReactions);
            Assert.IsNotNull(result.TopicComments);
            Assert.That(actualReactionCount, Is.EqualTo(expectedReactionCount));
        }

        [Test]
        public async Task DeleteShouldWorkProperly()
        {
            var addDeleteReactionRequest = new AddDeleteReactionRequestDto
            {
                CommentId = 1,
                ReactionType = ReactionTypeEnum.Like.ToString(),
                Skip = 0,
                Take = 1,
                TopicId = 1,
                UserId = MOCK_USER_ID
            };

            var result = await this._reactionsService.DeleteAsync(addDeleteReactionRequest);

            var updatedReaction = context.Set<Reaction>()
              .FirstOrDefault(r => r.CommentId == addDeleteReactionRequest.CommentId && r.UserId == 1 && r.ReactionType == Enum.Parse<ReactionTypeEnum>(addDeleteReactionRequest.ReactionType));

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.UserReactions);
            Assert.IsNotNull(result.TopicComments);
            Assert.IsTrue(updatedReaction.IsDeleted);
        }

        [Test]
        public async Task GetUserReactionsAsync()
        {
            string userId = MOCK_USER_ID;

            var expectedUserReactionsCount = context.Set<Reaction>()
                .Where(r => r.UserId == 1)
                .Count();

            var result = await this._reactionsService.GetUserReactionsAsync(userId);

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(expectedUserReactionsCount));
        }
    }
}
