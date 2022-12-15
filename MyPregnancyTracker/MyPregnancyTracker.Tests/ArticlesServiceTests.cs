
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Services.Models.ArticlesModels;
using MyPregnancyTracker.Services.Services.ArticlesService;

namespace MyPregnancyTracker.Tests
{
    public class ArticlesServiceTests : SetUp
    {
        private IArticlesService _articlesService;
        [SetUp]
        public async Task SetUp()
        {
            await InitializeDatabase();

            var configuartion = GetIConfiguration();
            var userManager = GetUserManager();
            var articlesRepository = GetArticlesRepository();
            var usersArticlesRepository = GetUsersArticlesRepository();
            var dataProtector = GetProtectionProvider();

            this._articlesService = new ArticlesService(configuartion, dataProtector, userManager, articlesRepository, usersArticlesRepository);
        }

        [Test]
        public async Task AddArticleShouldWorkProperly()
        {
            var addArticleRequest = new AddArticleRequestDto
            {
                Content = "Mocked content",
                Title = "Mocked title",
                UserId = MOCK_USER_ID
            };
            var expectedCount = context.Set<Article>().Count() + 1;

            var result = await this._articlesService.AddAsync(addArticleRequest);

            var actualCount = context.Set<Article>().Count();

            Assert.IsTrue(result);
            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public async Task AddReactionShouldWorkProperly()
        {
            var addReactionToArticleRequest = new AddReactionToArticleRequestDto
            {
                ArticleId = 2,
                IsLiked = true,
                Skip = 0,
                Take = 5,
                UserId = MOCK_USER_ID
            };
            var expectedReactionCount = context.Set<UserArticle>().Count() + 1;

            var result = await this._articlesService.AddReactionAsync(addReactionToArticleRequest);

            var actualReactionCount = context.Set<UserArticle>().Count();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Articles);
            Assert.That(actualReactionCount, Is.EqualTo(expectedReactionCount));
        }

        [Test]
        public async Task DeleteArticleShouldWorkProperly()
        {
            int articleId = 1;
            string userId = MOCK_USER_ID;

            var result = await this._articlesService.DeleteAsync(articleId, userId);

            var article = context.Set<Article>()
                .Where(a => a.Id == 1)
                .FirstOrDefault();

            Assert.IsTrue(result);
            Assert.IsTrue(article.IsDeleted);
        }

        [Test]
        public async Task EditAsyncShouldWorkProperly()
        {
            var editArticleRequest = new EditArticleRequestDto
            {
                Content = "Mocked content",
                Title = "Mocked title",
                Id = 1
            };

            string userId = MOCK_USER_ID;

            var result = await this._articlesService.EditAsync(editArticleRequest, userId);

            var article = context.Set<Article>()
                                .Where(a => a.Id == 1)
                                .FirstOrDefault();

            Assert.IsTrue(result);
            Assert.That(article.Content, Is.EqualTo(editArticleRequest.Content));
            Assert.That(article.Title, Is.EqualTo(editArticleRequest.Title));
        }

        [Test]
        public async Task GetAllShouldWorkProperly()
        {
            var getAllArticlesRequest = new GetAllArticlesRequestDto
            {
                UserId = MOCK_USER_ID,
                Skip = 0,
                Take = 1
            };

            var expectedArticlesCount = context.Set<Article>().Count();

            var result = await this._articlesService.GetAllAsync(getAllArticlesRequest);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Articles);
            Assert.That(result.ArticlesCount, Is.EqualTo(expectedArticlesCount));
        }
    }
}
