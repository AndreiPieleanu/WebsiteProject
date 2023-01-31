using Microsoft.AspNetCore.Authentication.Cookies;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using AspNetCoreHero.ToastNotification.Extensions;
using DataLayer.DALs;
using LogicLayer.Interfaces;
using LogicLayer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/Index");
    });
builder.Services.AddNotyf
(config =>
{
    config.DurationInSeconds = 10;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
});
builder.Services.AddSession(
    options =>
    {
        options.Cookie.Name = "CookieName";
        options.IdleTimeout = TimeSpan.FromHours(1);
        options.Cookie.IsEssential = true;
    }
);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton(_ =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new DbSettings(connectionString);
});

builder.Services.AddSingleton<IUserDal, UserDal>();
builder.Services.AddSingleton<ITagDal, TagDal>();
builder.Services.AddSingleton<INewsDal, NewsDal>();

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<NewsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; ;
            context.Response.ContentType = "text/html";

            await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
            await context.Response.WriteAsync("ERROR!<br><br>\r\n");

            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            {
                await context.Response.WriteAsync(
                    "File error thrown!<br><br>\r\n");
            }

            await context.Response.WriteAsync(
                "<a href=\"/\">Home</a><br>\r\n");
            await context.Response.WriteAsync("</body></html>\r\n");
            await context.Response.WriteAsync(new string(' ', 512));
        });
    });
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});
app.UseSession();

app.MapRazorPages();

app.Run();
