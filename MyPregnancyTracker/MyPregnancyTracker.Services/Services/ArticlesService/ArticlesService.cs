using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Models.ArticlesModels;
using SendGrid.Helpers.Errors.Model;

namespace MyPregnancyTracker.Services.Services.ArticlesService
{
    public class ArticlesService : IArticlesService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Article> _articlesRepository;
        private readonly IRepository<UserArticle> _userArticleRepository;
        private readonly IDataProtector _dataProtector;

        public ArticlesService(IConfiguration configuration,
            IDataProtectionProvider dataProtectionProvider,
            UserManager<ApplicationUser> userManager,
            IRepository<Article> articlesRepository,
            IRepository<UserArticle> userArticleRepository)
        {
            this._configuration = configuration;
            this._userManager = userManager;
            this._articlesRepository = articlesRepository;
            this._userArticleRepository = userArticleRepository;
            this._dataProtector = dataProtectionProvider.CreateProtector(this._configuration["DataProtectorKey"]);
        }

        public async Task<bool> AddAsync(AddArticleRequestDto addArticleRequest)
        {
            var unprotectedUserId = this._dataProtector.Unprotect(addArticleRequest.UserId);
            var user = await this._userManager.FindByIdAsync(unprotectedUserId);

            if(user == null)
            {
                return false;
            }

            var article = new Article
            {
                Content = addArticleRequest.Content,
                Title = addArticleRequest.Title
            };

            await this._articlesRepository.AddAsync(article);
            await this._articlesRepository.SaveChangesAsync();

            return true;
        }

        public async Task<ArticleDto> AddReactionAsync(AddReactionToArticleRequestDto addReactionToArticleRequest)
        {
            var unprotectedUserId = this._dataProtector.Unprotect(addReactionToArticleRequest.UserId);
            var user = await this._userManager.FindByIdAsync(unprotectedUserId);

            if (user == null)
            {
                throw new NotFoundException();
            }

            var article = await this._articlesRepository
                .GetAll()
                .FirstOrDefaultAsync(a => a.Id == addReactionToArticleRequest.ArticleId);

            if (article == null)
            {
                throw new NotFoundException();
            }

            var userArticle = await this._userArticleRepository
                .GetAll()
                .FirstOrDefaultAsync(ua => ua.ArticleId == addReactionToArticleRequest.ArticleId && ua.ApplicationUserId == int.Parse(unprotectedUserId));

            if (userArticle == null)
            {
                userArticle = new UserArticle
                {
                    ArticleId = addReactionToArticleRequest.ArticleId,
                    ApplicationUserId = int.Parse(unprotectedUserId),
                    IsLiked = addReactionToArticleRequest.IsLiked
                };

                await this._userArticleRepository.AddAsync(userArticle);
            }
            else
            {
                userArticle.IsLiked = addReactionToArticleRequest.IsLiked;
                this._userArticleRepository.Update(userArticle);
            }
       
            await this._userArticleRepository.SaveChangesAsync();

            return await this.GetOneByIdAsync(article.Id, addReactionToArticleRequest.UserId); 
        }

        public async Task<bool> DeleteAsync(int articleId, string userId)
        {
            var unprotectedUserId = this._dataProtector.Unprotect(userId);
            var user = await this._userManager.FindByIdAsync(unprotectedUserId);

            if (user == null)
            {
                return false;
            }

            var article = await this._articlesRepository
                .GetAll()
                .Where(a => a.Id == articleId && !a.DeletedOn.HasValue)
                .FirstOrDefaultAsync();

            if (article == null)
            {
                return false;
            }

            article.DeletedOn = DateTime.UtcNow;
            article.IsDeleted = true;
            this._articlesRepository.Update(article);
            await this._articlesRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditAsync(EditArticleRequestDto editArticleRequest, string userId)
        {
            var unprotectedUserId = this._dataProtector.Unprotect(userId);
            var user = await this._userManager.FindByIdAsync(unprotectedUserId);

            if (user == null)
            {
                return false;
            }

            var article = await this._articlesRepository
                .GetAll()
                .FirstOrDefaultAsync(a => a.Id == editArticleRequest.Id && !a.DeletedOn.HasValue);

            if (article == null)
            {
                return false;
            }

            article.Content = editArticleRequest.Content;
            article.Title = editArticleRequest.Title;

            this._articlesRepository.Update(article);
            await this._articlesRepository.SaveChangesAsync();

            return true;
        }

        public async Task<GetAllArticlesResponseDto> GetAllAsync(GetAllArticlesRequestDto getAllArticlesRequest)
        {
            var unprotectedUserId = this._dataProtector.Unprotect(getAllArticlesRequest.UserId);
            var user = await this._userManager.FindByIdAsync(unprotectedUserId);

            if (user == null)
            {
                throw new NotFoundException();
            }

            var articles = await this._articlesRepository
                .GetAll()
                .Include(a => a.UsersArticles)
                .Where(a => !a.DeletedOn.HasValue)
                .Select(a => new ArticleDto
                {
                    Id = a.Id,
                    Content = a.Content,
                    Title = a.Title,
                    IsLiked = a.UsersArticles
                        .FirstOrDefault(ua => ua.ArticleId == a.Id && ua.ApplicationUserId == int.Parse(unprotectedUserId)).IsLiked,
                    DislikesCount = a.UsersArticles
                        .Where(ua => ua.ArticleId == a.Id && ua.IsLiked.HasValue)
                        .Count(ua => !ua.IsLiked.Value),
                    LikesCount = a.UsersArticles
                        .Where(ua => ua.ArticleId == a.Id && ua.IsLiked.HasValue)
                        .Count(ua => ua.IsLiked.Value)
                })
                .ToListAsync();

            return new GetAllArticlesResponseDto
            {
                Articles = articles
                .Skip(getAllArticlesRequest.Skip)
                .Take(getAllArticlesRequest.Take)
                .ToList(),
                ArticlesCount = articles.Count
            };

        }

        public async Task<ArticleDto> GetOneByIdAsync(int articleId, string userId)
        {
            var unprotectedUserId = this._dataProtector.Unprotect(userId);
            var user = await this._userManager.FindByIdAsync(unprotectedUserId);

            if(user == null)
            {
                throw new NotFoundException();
            }

            var article = await this._articlesRepository
                .GetAll()
                .Include(a => a.UsersArticles)
                .FirstOrDefaultAsync(a => a.Id == articleId && !a.DeletedOn.HasValue);
                
            return new ArticleDto
            {
                Id = article.Id,  
                Content = article.Content,
                Title = article.Title,
                IsLiked = article.UsersArticles?
                    .FirstOrDefault(ua => ua.ArticleId == articleId && ua.ApplicationUserId == int.Parse(unprotectedUserId))?.IsLiked,
                DislikesCount = article.UsersArticles
                    .Where(ua => ua.ArticleId == articleId && ua.IsLiked.HasValue)
                    .Count(ua => !ua.IsLiked.Value),
                LikesCount = article.UsersArticles
                    .Where(ua => ua.ArticleId == articleId && ua.IsLiked.HasValue)
                    .Count(ua => ua.IsLiked.Value)                  
            };
        }

        public Task<IEnumerable<ArticleDto>> SearchAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
