using Microsoft.AspNetCore.Mvc;

namespace MyMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Welcome([FromServices] Services.GreetingService greetingService)
        {
            string message = greetingService.GetWelcomeMessage();
            return Content(message);
        }

        public IActionResult Time()
        {
            return Content(DateTime.Now.ToString("F"));
        }
    }
}
