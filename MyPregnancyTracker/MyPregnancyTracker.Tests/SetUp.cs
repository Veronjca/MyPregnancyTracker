using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using MyPregnancyTracker.Data;
using MyPregnancyTracker.Data.Enums;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using MyPregnancyTracker.Services.Config;
using MyPregnancyTracker.Services.EmailSender;
using MyPregnancyTracker.Services.Profiles;
using System.Text;

namespace MyPregnancyTracker.Tests
{
    public class SetUp
    {
        protected const string MOCK_REFRESH_TOKEN = "mockRefreshToken";
        protected const string MOCK_RESET_PASSWORD_TOKEN = "mockResetPasswordToken";
        protected const string MOCK_EMAIL_CONFIRMATION_TOKEN = "mockEmailConfirmationToken";
        protected const string MOCK_USER_ID = "mockUserId";
        protected const string MOCK_EMAIL_TOKEN = "mockEmailToken";
        protected const string MOCK_PROTECTED_EMAIL = "mockProtectedEmail";
        protected const string MOCK_PROTECTED_TASK_ID = "mockProtectedTaskId";

        protected MyPregnancyTrackerDbContext context;

        protected ICollection<ApplicationUser> users;
        protected ICollection<ApplicationRole> roles;
        protected ICollection<GestationalWeek> gestationalWeeks;
        protected ICollection<Article> articles;
        protected ICollection<Topic> topics;
        protected ICollection<Comment> comments;
        protected ICollection<Reaction> reactions;
        protected ICollection<MyPregnancyTrackerTask> myPregnancyTrackerTasks;
        protected ICollection<ApplicationUserMyPregnancyTrackerTask> usersTasks;
        protected ICollection<UserArticle> usersArticles;


        public async Task InitializeDatabase()
        {
            var options = new DbContextOptionsBuilder<MyPregnancyTrackerDbContext>()
               .UseInMemoryDatabase("MyPregnancyTrackerInMemoryDB").Options;

            this.context = new MyPregnancyTrackerDbContext(options);
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            this.users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = 1,
                    UserName = "Viki",
                    NormalizedUserName = "VIKI",
                    Email = "viki@gmail.com",
                    NormalizedEmail = "VIKI@GMAIL.COM",
                    EmailConfirmed = true,
                    CreatedOn = DateTime.UtcNow,
                    RefreshToken = MOCK_REFRESH_TOKEN,
                    RefreshTokenExpirationDate = DateTime.UtcNow.AddHours(1)
                },
                new ApplicationUser
                {
                    Id = 2,
                    UserName = "Paf",
                    NormalizedUserName = "PAF",
                    Email = "paf@gmail.com",
                    NormalizedEmail = "PAF@GMAIL.COM",
                    EmailConfirmed = true,
                    CreatedOn = DateTime.UtcNow,
                    RefreshToken = MOCK_REFRESH_TOKEN,
                    RefreshTokenExpirationDate = DateTime.UtcNow.AddHours(1)
                }
            };

            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, "A1234567a@");
            }

            this.roles = new List<ApplicationRole>
            {
                new ApplicationRole
                {
                   Id = 1,
                   Name = "user",
                   NormalizedName = "USER"
                },
                new ApplicationRole
                {
                    Id = 2,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
            };

            this.gestationalWeeks = new List<GestationalWeek>
            {
                new GestationalWeek
                {
                    Id = 1,
                    GestationalAge = 1,
                    BabyContent = "Gestatioanl week 1 baby content.",
                    AdvicesContent = "Gestational week 1 advices content.",
                    MotherContent = "Gestational week 1 mother content",
                    NutritionContent = "Gestational week 1 nutrition content"
                },
                new GestationalWeek
                {
                    Id = 2,
                    GestationalAge = 2,
                    BabyContent = "Gestatioanl week 2 baby content.",
                    AdvicesContent = "Gestational week 2 advices content.",
                    MotherContent = "Gestational week 2 mother content",
                    NutritionContent = "Gestational week 2 nutrition content"
                },
                new GestationalWeek
                {
                    Id = 3,
                    GestationalAge = 3,
                    BabyContent = "Gestatioanl week 3 baby content.",
                    AdvicesContent = "Gestational week 3 advices content.",
                    MotherContent = "Gestational week 3 mother content",
                    NutritionContent = "Gestational week 3 nutrition content"
                }
            };

            this.articles = new List<Article>
            {
                new Article
                {
                    Id = 1,
                    Title = "Title 1",
                    Content = "Article 1 content.",
                    CreatedOn = DateTime.UtcNow
                },
                new Article
                {
                    Id = 2,
                    Title = "Title 2",
                    Content = "Article 2 content.",
                    CreatedOn = DateTime.UtcNow
                },
                new Article
                {
                    Id = 3,
                    Title = "Title 3",
                    Content = "Article 3 content.",
                    CreatedOn = DateTime.UtcNow
                }
            };

            this.topics = new List<Topic>
            {
                new Topic
                {
                    Id = 1,
                    Title = "Topic title 1",
                    Content = "Topic 1 content.",
                    TopicCategory = TopicCategoryEnum.Toys,
                    CreatedOn = DateTime.UtcNow,
                    UserId = 1,
                },
                new Topic
                {
                    Id = 2,
                    Title = "Topic title 2",
                    Content = "Topic 2 content.",
                    TopicCategory = TopicCategoryEnum.Toys,
                    CreatedOn = DateTime.UtcNow,
                    UserId = 2,
                }
            };

            this.comments = new List<Comment>
            {
                new Comment
                {
                    Id = 1,
                    TopicId = 1,
                    UserId = 1,
                    Content = "Comment on topic 1.",
                    CreatedOn= DateTime.UtcNow,
                },
                new Comment
                {
                    Id = 2,
                    TopicId = 2,
                    UserId = 2,
                    Content = "Comment on topic 2.",
                    CreatedOn= DateTime.UtcNow,
                }
            };

            this.reactions = new List<Reaction>
            {
                new Reaction
                {
                    Id = 1,
                    CommentId = 1,
                    UserId = 1,
                    ReactionType = ReactionTypeEnum.Like,
                },
                new Reaction
                {
                    Id = 2,
                    CommentId = 2,
                    UserId = 2,
                    ReactionType = ReactionTypeEnum.Love,
                }
            };

            this.myPregnancyTrackerTasks = new List<MyPregnancyTrackerTask>
            {
                new MyPregnancyTrackerTask
                {
                    Id = 1,
                    Content = "Task 1",
                    CreatedOn = DateTime.UtcNow,
                    GestationalWeekId = 1,
                },
                new MyPregnancyTrackerTask
                {
                    Id = 2,
                    Content = "Task 2",
                    CreatedOn = DateTime.UtcNow,
                    GestationalWeekId = 2,
                },
                new MyPregnancyTrackerTask
                {
                    Id = 3,
                    Content = "Task 3",
                    CreatedOn = DateTime.UtcNow,
                    GestationalWeekId = 3,
                }
            };

            this.usersTasks = new List<ApplicationUserMyPregnancyTrackerTask>
            {
                new ApplicationUserMyPregnancyTrackerTask
                {
                    ApplicationUserId = 1,
                    MyPregnancyTrackerTaskId = 1,
                },
                new ApplicationUserMyPregnancyTrackerTask
                {
                    ApplicationUserId = 2,
                    MyPregnancyTrackerTaskId = 3
                }
            };

            this.usersArticles = new List<UserArticle>
            {
                new UserArticle
                {
                    ApplicationUserId = 1,
                    ArticleId = 1,
                },
                new UserArticle
                {
                    ApplicationUserId = 2,
                    ArticleId = 2
                }
            };

            await this.context.AddRangeAsync(this.users);
            await this.context.AddRangeAsync(this.roles);
            await this.context.AddRangeAsync(this.gestationalWeeks);
            await this.context.AddRangeAsync(this.articles);
            await this.context.AddRangeAsync(this.topics);
            await this.context.AddRangeAsync(this.comments);
            await this.context.AddRangeAsync(this.reactions);
            await this.context.AddRangeAsync(this.myPregnancyTrackerTasks);
            await this.context.AddRangeAsync(this.usersTasks);

            await this.context.SaveChangesAsync();
        }

        public UserManager<ApplicationUser> GetUserManager()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
            userManager.Object.UserValidators.Add(new UserValidator<ApplicationUser>());
            userManager.Object.PasswordValidators.Add(new PasswordValidator<ApplicationUser>());

            userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success)
                .Callback<ApplicationUser, string>((x,y) => users.Add(x));
            userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(this.users.First());
            userManager.Setup(x => x.IsEmailConfirmedAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(true);
            userManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(true);
            userManager.Setup(x => x.GetRolesAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(this.roles.Where(x => x.Name == "user").Select(x => x.Name).ToList());
            userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>()))
                .ReturnsAsync(this.users.First());
            userManager.Setup(x => x.GenerateEmailConfirmationTokenAsync(It.IsAny<ApplicationUser>()))
                .ReturnsAsync(MOCK_EMAIL_CONFIRMATION_TOKEN);
            userManager.Setup(x => x.ConfirmEmailAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            userManager.Setup(x => x.ResetPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny
                <string>()))
                .ReturnsAsync(IdentityResult.Success);

            return userManager.Object;
        }

        public IConfigurationRoot GetIConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public static IMapper GetMapper()
        {           
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationUserProfile>();
                cfg.AddProfile<MyPregnancyTrackerTaskProfile>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }

        public SendGridEmailSender GetEmailSender()
        {
            var config = this.GetIConfiguration();
            var key = config["SendGridApiKey"];

            var mockEmailSender = new Mock<SendGridEmailSender>(key);

            return mockEmailSender.Object;
        }

        public IOptions<MyPregnancyTrackerApplicationSettings> GetApplicationSettingsOptions()
        {
            var config = this.GetIConfiguration();
            var settings = new MyPregnancyTrackerApplicationSettings
            {
                BaseUrl = config.GetSection("MyPregnancyTrackerApplicationSettings").GetValue<string>("BaseUrl"),
                ConfirmEmailPageUrl = config.GetSection("MyPregnancyTrackerApplicationSettings").GetValue<string>("ConfirmEmailPageUrl"),
                ConfirmEmailTemplatePath = config.GetSection("MyPregnancyTrackerApplicationSettings").GetValue<string>("ConfirmEmailTemplatePath"),
                ResetPasswordEmailTemplatePath = config.GetSection("MyPregnancyTrackerApplicationSettings").GetValue<string>("ResetPasswordEmailTemplatePath"),
                ResetPasswordPageUrl = config.GetSection("MyPregnancyTrackerApplicationSettings").GetValue<string>("ResetPasswordPageUrl")
            };

            var options = Options.Create(settings);
            return options;
        }
        
        public IDataProtectionProvider GetProtectionProvider()
        {
            var mockedDataProtector = new Mock<IDataProtector>();
            mockedDataProtector.Setup(x => x.Protect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes("protected value"));
            mockedDataProtector.Setup(x => x.Unprotect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes("1"));

            var mockedProvider = new Mock<IDataProtectionProvider>();
            mockedProvider.Setup(x => x.CreateProtector(It.IsAny<string>())).Returns(mockedDataProtector.Object);

            return mockedProvider.Object;
        }

        public IRepository<ApplicationUserMyPregnancyTrackerTask> GetUsersTasksRepository()
        {
            var mocked = new Mock<EfRepository<ApplicationUserMyPregnancyTrackerTask>>(this.context);

            mocked.Setup(x => x.GetAll()).Returns(this.context.Set<ApplicationUserMyPregnancyTrackerTask>().AsQueryable());
            mocked.Setup(x => x.Delete(It.IsAny<ApplicationUserMyPregnancyTrackerTask>()))
                .Callback<ApplicationUserMyPregnancyTrackerTask>(x => context.Remove(x));

            return mocked.Object;
        }

        public IRepository<MyPregnancyTrackerTask> GetTaskRepository()
        {
            var mocked = new Mock<EfRepository<MyPregnancyTrackerTask>>(this.context);
            mocked.Setup(x => x.GetAll())
                .Returns(this.context.Set<MyPregnancyTrackerTask>()
                .AsQueryable());

            return mocked.Object;
        }

        public IRepository<Article> GetArticlesRepository()
        {
            var mocked = new Mock<EfRepository<Article>>(this.context);

            mocked.Setup(x => x.GetAll())
                .Returns(this.context.Set<Article>()
                .AsQueryable());
            mocked.Setup(x => x.AddAsync(It.IsAny<Article>()))
                .Callback<Article>(x => this.context.AddAsync(x));

            return mocked.Object;
        }

        public IRepository<UserArticle> GetUsersArticlesRepository()
        {
            var mocked = new Mock<EfRepository<UserArticle>>(this.context);
            mocked.Setup(x => x.GetAll())
                .Returns(this.context.Set<UserArticle>()
                .AsQueryable());
            mocked.Setup(x => x.AddAsync(It.IsAny<UserArticle>()))
                .Callback<UserArticle>(x => this.context.AddAsync(x));

            return mocked.Object;
        }

        public IRepository<Topic> GetTopicsRepository()
        {
            var mocked = new Mock<EfRepository<Topic>>(this.context);

            mocked.Setup(x => x.GetAll())
                .Returns(this.context.Set<Topic>().AsQueryable());
            mocked.Setup(x => x.AddAsync(It.IsAny<Topic>()))
                .Callback<Topic>(x => this.context.AddAsync(x));

            return mocked.Object;
        }

        public IRepository<ApplicationUser> GetUserRepository()
        {
            var mocked = new Mock<EfRepository<ApplicationUser>>(this.context);
            return mocked.Object;
        }

        public IRepository<Comment> GetCommentsRepository()
        {
            var mocked = new Mock<EfRepository<Comment>>(this.context);

            mocked.Setup(x => x.GetAll())
                .Returns(this.context.Set<Comment>());
            mocked.Setup(x => x.AddAsync(It.IsAny<Comment>()))
                .Callback<Comment>(x => this.context.AddAsync(x));

            return mocked.Object;
        }

        public IRepository<GestationalWeek> GetGestationalWeekRepository()
        {
            var mocked = new Mock<EfRepository<GestationalWeek>>(this.context);

            mocked.Setup(x => x.GetAll())
                .Returns(this.context.Set<GestationalWeek>().AsQueryable());

            return mocked.Object;
        }

        public IRepository<Reaction> GetReactionsRepository()
        {
            var mocked = new Mock<EfRepository<Reaction>>(this.context);

            mocked.Setup(x => x.GetAll())
                .Returns(this.context.Set<Reaction>().AsQueryable());
            mocked.Setup(x => x.AddAsync(It.IsAny<Reaction>()))
                .Callback<Reaction>(x => this.context.AddAsync(x));

            return mocked.Object;
        }

        [TearDown]
        public void AfterAll()
        {
            this.context.Database.EnsureDeleted();
        }

    }
}
