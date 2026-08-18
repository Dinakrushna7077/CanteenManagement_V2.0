using CanteenManagement_2._0.Models;
using CanteenManagement_2._0.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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

            var dept = await service.AllDepartmentsAsync();
            List<Honour>honours=new List<Honour>();

            ViewBag.Department = new SelectList(dept, "Id", "DeptName");
            ViewBag.Honours = new SelectList(honours, "Id", "HonoursName");

            return PartialView("_NewCustomer");
        }
        [HttpGet("get-honours")]
        public async Task<IActionResult> GetHonoursByDeptId(int deptId)
        {
            List<Honour> honours = await service.GetHonoursAsync(deptId);
            return Json(honours);
        }
        [HttpPost("add-customer")]
        public async Task<IActionResult> NewCustomer(Customer cust)
        {
            ResponseViewModel<int> response = new ResponseViewModel<int>();
            var uid = HttpContext.Session.GetString("uid");
            if (uid == null)
            {
                response.Message = "Access Denied...";
                return Unauthorized(response);
            }
            long createdBy = Convert.ToInt64(uid);
            response= await service.NewCustomerAsync(cust,createdBy);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
