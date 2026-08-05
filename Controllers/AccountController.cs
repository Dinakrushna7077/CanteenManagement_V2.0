using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel data)
        {
            var userData=await service.UserLogin(data);
            data.Message = userData.Message;
            if (!userData.Success)
                return Task.FromResult(Json(new { success = false, message = userData.Message })).Result;
            /*if(userData.user.RoleId==1)
                return RedirectToAction("SuperAdminDashboard");
            if(userData.user.RoleId==2)
                return RedirectToAction("AdminDashboard");
            if(userData.user.RoleId==3)
                return RedirectToAction("CustomerDashboard");*/
            return Task.FromResult(Json(new { success = true, message = userData.Message, redirectUrl = Url.Action("Index", "Home") })).Result;
        }
    }
}
