using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NuGet.Packaging;
using SysAdmDip4.Controllers;
using SysAdmDip4.Data;
//using SysAdmDip4.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SysAdmDip4Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SysAdmDip4Context") ?? throw new InvalidOperationException("Connection string 'SysAdmDip4Context' not found.")));

//builder.Services.AddRazorPages(options =>
//{
//    //options.Conventions.AuthorizeFolder("/Views/Article");
//    options.Conventions.AuthorizeFolder("/Views/System");
//});

#region make it reach the folder of views
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews(options =>
    {
        var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        options.Filters.Add(new AuthorizeFilter(policy));///Set global authority filter
    }
)
    .AddRazorOptions(options =>
    {
        //options.ViewLocationFormats.Clear();///Clear the original path
        options.ViewLocationFormats.Add("/views/System/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/views/Article/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/views/Shared/{0}.cshtml");
    });
#endregion

#region verify the user with login
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Login";
        options.AccessDeniedPath = "/Home/AccessDenied";
    });
builder.Services.AddAuthenticationCore();
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

#region using the verify code
app.UseAuthentication();
app.UseAuthorization();
#endregion


app.MapControllerRoute(
    name: "default", //The default page
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
