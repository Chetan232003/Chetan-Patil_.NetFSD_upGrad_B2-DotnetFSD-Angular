using Microsoft.AspNetCore.Mvc;

namespace Week 7 (Day 2).Controllers
{
    [Route("Calculator")]
    public class CalculatorController : Controller
    {
        
        [Route("AddNumbers",Name = "AddNumbers")]
        public IActionResult AddNumbers()
        {
            return View();
        }
        [HttpPost("AddNumbers")]
        [Route("Sum",Name ="Sum")]
        public IActionResult AddNumbers(int num1,int num2)
        {
            int sum = num1 + num2;
            ViewBag.sum = sum;
            return View("AddNumbers");
        }
    }
}
