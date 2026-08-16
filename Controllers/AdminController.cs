using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CanteenManagement_2._0.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService service;
        public AdminController(IAdminService _service)
        {
            service= _service;
        }
        [HttpGet("add-customer")]
        public async Task<IActionResult> NewCustomer()
        {
            List<string> alias = await service.GetAliasAsync(10);
            ViewBag.Alias = alias.Select(x => new SelectListItem{Value = x,Text = x}).ToList();
            return PartialView("_NewCustomer");
        }
        [HttpPost("add-customer")]
        public async Task<IActionResult> NewCustomer(Customer cust)
        {
            ResponseViewModel<int> response = await service.NewCustomerAsync(cust);
            if(response.Success)
            {
                return PartialView(response);
            }
            return PartialView("_NewCustomer",response);
        }
    }
}
