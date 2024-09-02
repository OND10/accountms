using AccountingManagementSystem.Application.Extensions;
using AccountingManagementSystem.Application.Services.Accounts.Implementation;
using AccountingManagementSystem.Application.Services.Accounts.Interface;
using AccountingManagementSystem.Application.Services.Transactions.Implementation;
using AccountingManagementSystem.Application.Services.Transactions.Interface;
using AccountingManagementSystem.Infustracture.Extensions;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Add custom application and persistence layers
builder.Services.AddApplication();
builder.Services.AddPresistence(builder.Configuration);

// Configure session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configure cookie-based authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login"; // Redirect to login page if not authenticated
        options.AccessDeniedPath = "/Auth/AccessDenied"; // Redirect to access denied page
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie expiration
    });

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add authentication and session middleware
app.UseAuthentication(); // Must be added before UseAuthorization
app.UseSession();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    var path = context.Request.Path.ToString().ToLower();

    // List of paths that do not require authentication
    var unrestrictedPaths = new List<string> { "/auth/login", "/auth/register", "/home/index" };

    if (!unrestrictedPaths.Contains(path) && context.Session.GetString("User") == null)
    {
        // Redirect to login if the user is not authenticated
        context.Response.Redirect("/Auth/Login");
        return; // Prevent further processing if redirecting
    }

    await next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
