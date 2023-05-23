using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysAdmDip4.Data;
using SysAdmDip4.Models;
using System.Diagnostics;
using System.Security.Claims;

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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            var member = await _context.Member.FirstOrDefaultAsync(m => m.Member_Email == Email);
            if (member == null || member.Member_Password != Password)
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
                    new ClaimsPrincipal(claimsIdentity),authProperties);
            }
            catch (Exception ex) { return NotFound(); }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}