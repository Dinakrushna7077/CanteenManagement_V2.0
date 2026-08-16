using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CanteenManagement_2._0.Controllers
{
    [Route("canteen")]
    public class AccountController : Controller
    {
        private readonly IAccountService service;
        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        [HttpGet("login")]
        public IActionResult Login() => View();

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel data)
        {
            var userData=await service.UserLogin(data);
            data.Message = userData.Message;
            if (!userData.Success)
                return Json(new
                {
                    success = false,
                    message = userData.Message
                });
            
            HttpContext.Session.SetString("uid", userData.user.Id.ToString());
            HttpContext.Session.SetString("role", userData.user.RoleId.ToString());

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userData.user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userData.user.Id.ToString()) 
            };

            if (userData.user.RoleId == 1)
            {
                claims.Add(new Claim(ClaimTypes.Role, "SuperAdmin"));
            }
            else if (userData.user.RoleId == 2)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else if (userData.user.RoleId == 3)
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Json(new
            {
                success = true,
                message = userData.Message,
                redirectUrl = Url.Action("dashboard", "Home")
            });
        }
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }
    }
}
