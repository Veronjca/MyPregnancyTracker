using MyPregnancyTracker.Data.Enums;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.TopicsModels;
using MyPregnancyTracker.Services.Services.TopicsService;

namespace MyPregnancyTracker.Tests
{
    public class TopicsServiceTests: SetUp
    {
        private ITopicsService _topicsService;

        [SetUp]
        public async Task SetUp()
        {
            await InitializeDatabase();

            var topicsRepository = GetTopicsRepository();
            var configuration = GetIConfiguration();
            var dataProtector = GetProtectionProvider();
            var userManager = GetUserManager();
            var mapper = GetMapper();

            this._topicsService = new TopicsService(topicsRepository, configuration, dataProtector, userManager, mapper);
        }

        [Test]
        public async Task AddTopicShouldWorkProperly()
        {
            var addTopicDto = new AddTopicDto
            {
                Category = TopicCategoryEnum.Toys,
                Content = "Mock topic content",
                Title = "Mock topic title",
                UserId = MOCK_USER_ID
            };

            var expectedTopicsCount = context.Set<Topic>()
                .Where(t => t.UserId == 1)
                .Count() + 1;

            var result = await this._topicsService.AddTopicAsync(addTopicDto);

            var actualTopicsCount = context.Set<Topic>()
              .Where(t => t.UserId == 1)
              .Count();

            Assert.IsTrue(result);
            Assert.That(actualTopicsCount, Is.EqualTo(expectedTopicsCount));
        }

        [Test]
        public async Task GetAllShouldWorkProperly()
        {
            var getAllTopicsRequest = new GetAllTopicsRequestDto
            {
                Category = 1,
                IsDescendingOrder = true,
                Skip = 0,
                Take = 5
            };

            var expectedTopicsCount = context.Set<Topic>()
                .Where(t => t.TopicCategory == Enum.Parse<TopicCategoryEnum>(getAllTopicsRequest.Category.ToString()))
                .Count();

            var result = await this._topicsService.GetAllAsync(getAllTopicsRequest);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Topics);
            Assert.That(result.TopicsCount, Is.EqualTo(expectedTopicsCount));
        }

        [Test]
        public async Task GetOneShouldWorkProperly()
        {
            int topicId = 1;

            var topic = context.Set<Topic>()
                .FirstOrDefault(t => t.Id == topicId);

            var result = await this._topicsService.GetOneAsync(topicId);

            Assert.IsNotNull(result);
            Assert.That(int.Parse(result.Id), Is.EqualTo(topic.Id));
        }

        [Test]
        public async Task GetUserTopicsShouldWorkProperly()
        {
            string userId = MOCK_USER_ID;

            var expectedUserTopicsCount = context.Set<Topic>()
                .Where(t => t.UserId == 1)
                .Count();

            var result = await this._topicsService.GetUserTopicsAsync(userId);

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(expectedUserTopicsCount));
        }

        [Test]
        public async Task DeleteTopicShouldWorkProperly()
        {
            int topicId = 1;
            string userId = MOCK_USER_ID;

            var result = await this._topicsService.DeleteTopicAsync(topicId, userId);

            var updatedTopic = context.Set<Topic>()
             .FirstOrDefault(t => t.Id == topicId && t.UserId == 1);

            Assert.IsTrue(result);
            Assert.IsTrue(updatedTopic.IsDeleted);
        }

        [Test]
        public async Task EditTopicShouldWorkProperly()
        {
            string userId = MOCK_USER_ID;
            var topicDto = new TopicDto
            {
                Category = TopicCategoryEnum.Toys,
                Content = "Some mocked edit topic content",
                CreatedOn = DateTime.Now,
                Id = "1",
                Title = "Mocked topic title",
                UserId = MOCK_USER_ID,
                UserName = "Mocked user name"
            };

            var result = await this._topicsService.EditTopicAsync(topicDto, userId);

            var updatedTopic = context.Set<Topic>()
                    .FirstOrDefault(t => t.Id == int.Parse(topicDto.Id) && t.UserId == 1);

            Assert.IsTrue(result);
            Assert.That(updatedTopic.Content, Is.EqualTo(topicDto.Content));
        }
    }
}
