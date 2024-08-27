using UndecidedApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using UndecidedApp.Areas.Identity;
using UndecidedApp.Data;
using UndecidedApp.Data.Models.AuthModels;
using UndecidedApp.Shared;
using UndecidedApp;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
var connectionStringAuth = builder.Configuration.GetConnectionString("UndecidedAuth") ?? throw new InvalidOperationException("Connection string 'UndecidedAuth' not found.");
var connectionStringDB = builder.Configuration.GetConnectionString("UndecidedDB") ?? throw new InvalidOperationException("Connection string 'UndecidedDB' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionStringAuth));
builder.Services.AddDbContext<UndecidedDBContext>(
 opt => opt.UseMongoDB(
     connectionStringDB,
     "DrTechDbMongo"
     ));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
    (
        connectionStringDB,
        "DrTechDbMongo"
    ).AddRoles<ApplicationRole>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IColorModeService, ColorModeService>();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddAuthentication().AddGoogle(opt =>
{
    opt.ClientId = configuration["GoogleAuth:ClientId"];
    opt.ClientSecret = configuration["GoogleAuth:ClientSecret"];

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseAntiforgery();

//app.MapControllers();
//app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
