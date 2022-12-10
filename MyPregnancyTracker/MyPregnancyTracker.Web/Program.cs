using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyPregnancyTracker.Data;
using static MyPregnancyTracker.Web.Constants.Constants.Validation;
using static MyPregnancyTracker.Web.Constants.Constants.Swagger;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyPregnancyTracker.Services;
using MyPregnancyTracker.Services.EmailSender;
using IEmailSender = MyPregnancyTracker.Services.EmailSender.IEmailSender;
using MyPregnancyTracker.Services.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringBuilder = new SqlConnectionStringBuilder(builder.Configuration[builder.Configuration.GetConnectionString("DefaultConnection")]);
connectionStringBuilder.UserID = builder.Configuration["User"];
connectionStringBuilder.Password = builder.Configuration["Password"];

string connectionString = connectionStringBuilder.ConnectionString;

builder.Services.AddDbContext<MyPregnancyTrackerDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;

    opt.Password.RequiredLength = PASSWORD_MIN_LENGTH;

    opt.SignIn.RequireConfirmedEmail = true;

    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

}).AddEntityFrameworkStores<MyPregnancyTrackerDbContext>()
.AddDefaultTokenProviders();

var jwtKey = Encoding.ASCII.GetBytes(builder.Configuration["JwtSecretKey"]);


builder.Services
    .AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

builder.Services.AddAuthorization();

var ngAppSettings = builder.Configuration.GetSection("MyPregnancyTrackerApplicationSettings");
builder.Services.Configure<MyPregnancyTrackerApplicationSettings>(ngAppSettings);

builder.Services.AddDataProtection();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddServiceLayer();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddTransient<IEmailSender>(options => new SendGridEmailSender(builder.Configuration["SendGridApiKey"]));

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Version = "v1", 
        Title = "MyPregnancyTracker.Api", 
        Description = "Api for MyPregnancyTracker web app.Personal information source about pregnancy and all about it.",
    });

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "Jwt",
        Name = "JwtAuthentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Insert your token value without the 'Bearer' key word.",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    opt.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSecurityScheme, Array.Empty<String>() }
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(SWAGGER_ENDPOINT, SWAGGER_VERSION);
        options.RoutePrefix = String.Empty;
    });
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();