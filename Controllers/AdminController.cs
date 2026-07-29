using Microsoft.AspNetCore.Mvc;

namespace CanteenManagement_2._0.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
