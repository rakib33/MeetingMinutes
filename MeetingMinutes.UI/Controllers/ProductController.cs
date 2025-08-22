using MeetingMinutes.Application.Interfaces;
using MeetingMinutes.Domain.Entities;
using MeetingMinutes.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeetingMinutes.Controllers
{
    public class ProductController : Controller
    {
       private readonly IProductService _productService;
       public  ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        // Get products for dropdown
        public async Task<JsonResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
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
