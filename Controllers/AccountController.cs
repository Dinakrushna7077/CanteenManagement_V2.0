using Microsoft.AspNetCore.Mvc;

namespace CanteenManagement_2._0.Controllers
{
    [Route("canteen")]
    public class AccountController : Controller
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
