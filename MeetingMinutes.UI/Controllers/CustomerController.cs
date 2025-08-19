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
                new Customer { Id = 1, Name = "Rubel"},
                new Customer { Id = 2, Name = "Fahim"},
                new Customer { Id = 3, Name = "Imtiaz"},
           
            };
            return Json(customers);
        }

        //Individual_Customer_Tbl
        public JsonResult GetIndividualCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Sojib"},
                new Customer { Id = 2, Name = "Rayhan"},
                new Customer { Id = 3, Name = "Manik"},

            };
            return Json(customers);
        }
    }
}
