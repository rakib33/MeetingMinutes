using MeetingMinutes.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeetingMinutes.UI.Controllers
{
    public class CustomerController : Controller
    {     

        //Corporate_Customer_Tbl        
        public JsonResult GetCorporateCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "A"},
                new Customer { Id = 2, Name = "B"},
                new Customer { Id = 3, Name = "C"},
           
            };
            return Json(customers);
        }

        //Individual_Customer_Tbl
        public JsonResult GetIndividualCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "D"},
                new Customer { Id = 2, Name = "E"},
                new Customer { Id = 3, Name = "F"},

            };
            return Json(customers);
        }
    }
}
