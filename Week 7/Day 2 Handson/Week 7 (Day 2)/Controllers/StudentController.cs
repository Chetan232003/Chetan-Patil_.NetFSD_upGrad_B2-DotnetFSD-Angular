using Microsoft.AspNetCore.Mvc;

namespace Week 7 (Day 2).Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        
        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(string studentName, int age, string course)
        {
            ViewBag.Name = studentName;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View("Display");
        }
    }
}
