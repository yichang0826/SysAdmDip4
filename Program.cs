using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SysAdmDip4.Data;
//using SysAdmDip4.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SysAdmDip4Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SysAdmDip4Context") ?? throw new InvalidOperationException("Connection string 'SysAdmDip4Context' not found.")));

//============================================================================================

//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        //options.ViewLocationFormats.Clear();
        options.ViewLocationFormats.Add("/views/System/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/views/Shared/{0}.cshtml");
    });

//============================================================================================
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Login";
        options.AccessDeniedPath = "/Home/AccessDenied";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("admin"));
});
//============================================================================================


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

//≈Á√“
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
