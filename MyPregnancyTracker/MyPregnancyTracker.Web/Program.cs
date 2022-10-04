using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyPregnancyTracker.Data;
using static MyPregnancyTracker.Data.Constants.ValidationConstants;
using MyPregnancyTracker.Data.Models;
using MyPregnancyTracker.Data.Repositories;
using Microsoft.OpenApi.Models;

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
    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = PASSWORD_MIN_LENGTH;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireNonAlphanumeric = true;
    opt.SignIn.RequireConfirmedEmail = true;

}).AddEntityFrameworkStores<MyPregnancyTrackerDbContext>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Version = "v1", 
        Title = "MyPregnancyTracker.Api", 
        Description = "Api for MyPregnancyTracker web app.Personal information source about pregnancy and all about it.",
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
