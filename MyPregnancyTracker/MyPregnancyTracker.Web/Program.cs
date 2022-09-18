using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyPregnancyTracker.Data;
using MyPregnancyTracker.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringBuilder = new SqlConnectionStringBuilder(builder.Configuration[builder.Configuration.GetConnectionString("DefaultConnection")]);
connectionStringBuilder.UserID = builder.Configuration["User"];
connectionStringBuilder.Password = builder.Configuration["Password"];

string connectionString = connectionStringBuilder.ConnectionString;

builder.Services.AddDbContext<MyPregnancyTrackerDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

builder.Services.AddControllers();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<MyPregnancyTrackerDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
