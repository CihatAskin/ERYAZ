using ERYAZ.WebClient.Models.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using ERYAZ.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<LogOnModel>(builder.Configuration.GetSection("LogOn"));
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddAuthorization();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(x =>
                   {
                       x.Cookie.Name = "ERYAZ";
                       x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                       x.Cookie.SameSite = SameSiteMode.Strict;
                       x.Cookie.HttpOnly = true;
                       x.Cookie.IsEssential = true;
                       x.SlidingExpiration = true;
                       x.ExpireTimeSpan = TimeSpan.FromHours(8);
                       x.LoginPath = "/User/LogOn";
                       x.LogoutPath = "/User/LogOff";
                       x.AccessDeniedPath = "/Home/Error";

                   });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
