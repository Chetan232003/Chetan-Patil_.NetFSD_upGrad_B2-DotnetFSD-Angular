using Microsoft.AspNetCore.Mvc;

namespace Week 7 (Day 2).Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        [HttpGet("form")]
        [Route("/")]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(string name, string comments, int rating)
        {
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You for your positive feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }

            ViewData["UserName"] = name;

            return View("Result");
        }
    }
}
