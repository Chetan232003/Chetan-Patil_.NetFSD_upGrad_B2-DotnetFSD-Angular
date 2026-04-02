using Microsoft.AspNetCore.Mvc;

namespace Week 7 (Day 2).Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private static List<dynamic> products = new List<dynamic>();

        
        [HttpGet("AddProducts")]
        public IActionResult AddProducts()
        {
            ViewBag.Products = products;
            return View();
        }

        [HttpPost("add")]
        public IActionResult Add(string productName, double price, int quantity)
        {
            products.Add(new
            {
                Name = productName,
                Price = price,
                Quantity = quantity
            });

            ViewBag.Products = products;

            return View("AddProducts");
        }
    }
}

