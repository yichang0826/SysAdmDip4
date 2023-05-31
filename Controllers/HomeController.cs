using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysAdmDip4.Data;
using SysAdmDip4.Models;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace SysAdmDip4.Controllers
{
    public class HomeController : Controller
    {
        private readonly SysAdmDip4Context _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, SysAdmDip4Context context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Knowleges");
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            var member = await _context.Member.FirstOrDefaultAsync(m => m.Member_Email == Email);
            if (member.Member_Active == 0)
            {
                ViewData["Danger"] = "You have been BANED";
                return View();
            }
            else if (member == null || member.Member_Password != Password)
            {
                ViewData["Danger"] = "Invald Email or Password";
                return View();
            }

            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, member.Member_Name ?? "Admin"),
                    new Claim(ClaimTypes.Role, member.Member_RoleId.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    // Uncomment the following line to persist user authentication after the browser is closed.
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = true,
                    AllowRefresh = false
                };
                await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);
            }
            catch (Exception) { return NotFound(); }
            return RedirectToAction("Index", "Knowleges");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> KnowlegeDetail(int Id)
        {
            var model = await _context.Knowlege
                .Include(k => k.Knowlege_Classify)
                .Include(k => k.Knowlege_Comment)
                .FirstOrDefaultAsync(m => m.Knowlege_Id == Id);
            
            if (model != null)
            {
                model.Knowlege_ViewCount++;
                _context.SaveChanges();
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}