
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.CommentsModels;
using MyPregnancyTracker.Services.Services.CommentsService;

namespace MyPregnancyTracker.Tests
{
    public class CommentsServiceTests : SetUp
    {
        private ICommentsService _commentsService;
        [SetUp]
        public async Task SetUp()
        {
            await InitializeDatabase();

            var configuration = GetIConfiguration();
            var dataProtector = GetProtectionProvider();
            var topicsRepository = GetTopicsRepository();
            var commentsRepository = GetCommentsRepository();
            var userManager = GetUserManager();

            this._commentsService = new CommentsService(configuration, dataProtector, topicsRepository, commentsRepository, userManager);
        }

        [Test]
        public async Task AddShouldWorkProperly()
        {
            var addCommentRequest = new AddCommentRequestDto
            {
                Content = "Mocked content",
                TopicId = 1,
                UserId = MOCK_USER_ID
            };

            var expectedCommentsCount = context.Set<Comment>().Count() + 1;

            var result = await this._commentsService.AddAsync(addCommentRequest);

            var actualCommentsCount = context.Set<Comment>().Count();

            Assert.IsTrue(result);
            Assert.That(actualCommentsCount, Is.EqualTo(expectedCommentsCount));
        }

        [Test]
        public async Task DeleteShouldWorkProperly()
        {
            int commentId = 1;
            string userId = MOCK_USER_ID;

            var result = await this._commentsService.DeleteAsync(commentId, userId);

            var updatedComment = context.Set<Comment>()
                    .Where(c => c.Id == commentId)
                    .FirstOrDefault();

            Assert.IsTrue(result);           
            Assert.IsTrue(updatedComment.IsDeleted);
        }

        [Test]
        public async Task EditShouldWorkProperly()
        {
            var editCommentDto = new EditCommentDto
            {
                Content = "Mocked content",
                TopicId = 1,
                UserId = MOCK_USER_ID,
                Id = 1
            };

            string userId = MOCK_USER_ID;

            var result = await this._commentsService.EditAsync(editCommentDto, userId);

            var updatedComment = context.Set<Comment>()
                  .Where(c => c.Id == editCommentDto.Id)
                  .FirstOrDefault();

            Assert.IsTrue(result);
            Assert.That(updatedComment.Content, Is.EqualTo(editCommentDto.Content));
        }

        [Test]
        public async Task GetAllShouldWorkProperly()
        {
            var getAllCommentsRequest = new GetAllCommentsRequestDto
            {
                TopicId = 1,
                Skip = 0,
                Take = 5
            };
            var expectedCommentsCount = context.Set<Comment>()
                .Where(c => c.TopicId == getAllCommentsRequest.TopicId)
                .Count();

            var result = await this._commentsService.GetAllAsync(getAllCommentsRequest);

            Assert.IsNotNull(result);    
            Assert.IsNotNull(result.Comments);
            Assert.That(result.CommentsCount, Is.EqualTo(expectedCommentsCount));
        }

        [Test]
        public async Task GetUserCommentsShouldWorkProperly()
        {
            string userId = MOCK_USER_ID;
            int topicId = 1;

            var result = await this._commentsService.GetUserCommentsAsync(userId, topicId);

            var expectedUserCommentsCount = context.Set<Comment>()
                .Where(c => c.UserId == 1 && c.TopicId == topicId)
                .Count();

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(expectedUserCommentsCount));
        }
    }
}
