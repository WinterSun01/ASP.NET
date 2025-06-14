using Microsoft.AspNetCore.Mvc;
using ReviewApp.Models;
using ReviewApp.Services;

namespace ReviewApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReviewService _reviewService;

        public HomeController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {
            var reviews = _reviewService.GetLastReviews(20);
            return View(reviews);
        }

        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            Console.WriteLine($"AddReview called: Author={review.Author}, Message={review.Message}, Rating={review.Rating}");

            if (string.IsNullOrWhiteSpace(review.Author) ||
                string.IsNullOrWhiteSpace(review.Message) ||
                review.Rating < 1 || review.Rating > 5)
            {
                return BadRequest("Invalid review data.");
            }

            _reviewService.AddReview(review);
            return RedirectToAction("Index");
        }




    }
}
