using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiddlewareDemo.Models;

namespace MiddlewareDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            long elapsed = 0;

            if (HttpContext.Items.ContainsKey("RequestTime"))
            {
                elapsed = (long)HttpContext.Items["RequestTime"];
            }

            _logger.LogInformation("Request time from middleware: {Elapsed} ms", elapsed);

            var model = new ResultViewModel
            {
                ElapsedMilliseconds = elapsed
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
