using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MeetingMinutes.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        //Corporate_Customer_Tbl        
        public async Task<JsonResult> GetCorporateCustomers()
        {
            var customers = await _customerService.GetCorporateCustomersAsync();   
            return Json(customers);
        }

        // Change the method signature to async and return Task<JsonResult>
        public async Task<JsonResult> GetIndividualCustomers()
        {
            var customers = await _customerService.GetIndividualCustomersAsync();
            return Json(customers);
        }
    }
}
