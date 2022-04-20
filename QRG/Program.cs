using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QRG;
using QRG.Data;
using QRG.Models;
using QRG.Services;
using QRG.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IProjectService, ProjectService>();
SD.JiraApiBase = builder.Configuration["JiraService:JiraApiUrl"];
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

try
{
    var _serviceScope = app.Services.CreateScope();
    var dbInitializer = _serviceScope.ServiceProvider.GetRequiredService<IDbInitializer>();
    dbInitializer.Initialize();


}
catch (Exception ex)
{
    throw new Exception("Can't initialize role types " + ex.Message);
}

app.Run();
