
using BlazorGoogleMongo.Authentication;
using CarRentalApp.Components;
using CarRentalApp.Services;
using Dal;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


// 1. Bind MongoDB configuration from appsettings.json
builder.Services.Configure<DbRegistration>(
    builder.Configuration.GetSection("MongoDBSettings"));

// 2. Register DbRegistration for direct injection
builder.Services.AddSingleton(resolver =>
    resolver.GetRequiredService<IOptions<DbRegistration>>().Value);


// Register services 


builder.Services.AddSingleton<ICarService, ServiceCar>();
builder.Services.AddSingleton<IBusService, ServiceBus>();
builder.Services.AddSingleton<IHiaceService, ServiceHiace>();
builder.Services.AddSingleton<ICarPackageService, ServiceCarPackage>();
builder.Services.AddSingleton<IBusPackageService, ServiceBusPackage>();
builder.Services.AddSingleton<IHiacePackageService, ServiceHiacePackage>();
builder.Services.AddScoped<CarRentalApp.Services.IAboutShowroomService, AboutShowroomService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<BusinessCheckService>();
builder.Services.AddScoped<IImageUploadService, ImageUploadService>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
builder.Services.AddAuthentication(AppConstants.AuthScheme)
    .AddCookie(AppConstants.AuthScheme, cookieOptions =>
    {
        cookieOptions.Cookie.Name = AppConstants.AuthScheme;
    })
    .AddGoogle(GoogleDefaults.AuthenticationScheme, googleOptions =>
    {
        string? clientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
        string? clientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");

        googleOptions.ClientId = clientId ?? throw new InvalidOperationException("GOOGLE_CLIENT_ID not set");
        googleOptions.ClientSecret = clientSecret ?? throw new InvalidOperationException("GOOGLE_CLIENT_SECRET not set");

        googleOptions.AccessDeniedPath = "/access-denied";
        googleOptions.SignInScheme = AppConstants.AuthScheme;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
