using CanteenManagement_2._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CanteenManagement_2._0.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> SubmitQuery(PublicQuery qry)
        {
            //Service call to save the query in the database
            return await Task.FromResult<IActionResult>(Json(new {success = true, message = "Query submitted successfully!"}));
        }
    }
}
