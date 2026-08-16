using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult NewCustomer() => PartialView("_NewCustomer");
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
