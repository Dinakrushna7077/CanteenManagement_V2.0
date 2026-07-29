using Microsoft.AspNetCore.Mvc;

namespace CanteenManagement_2._0.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
