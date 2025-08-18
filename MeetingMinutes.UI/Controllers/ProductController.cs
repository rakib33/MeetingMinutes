using MeetingMinutes.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeetingMinutes.Controllers
{
    public class ProductController : Controller
    {
        // Get products for dropdown
        public JsonResult GetProducts()
        {
        
            var products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Unit = 10 },
            new Product { Id = 2, Name = "Mouse", Unit = 20 },
            new Product { Id = 3, Name = "Keyboard", Unit = 30 },
            new Product { Id = 4, Name = "Monitor", Unit = 15 },
            new Product { Id = 5, Name = "Paper", Unit = 5 }
        };
            return Json(products);
        }

        // Save products
        [HttpPost]
        public JsonResult SaveProducts([FromBody] List<Product> products)
        {
            try
            {
                // Save logic
                return Json(new { success = true, message = "Products saved successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
