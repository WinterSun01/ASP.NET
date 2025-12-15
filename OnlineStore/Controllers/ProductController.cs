using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Domain;
using OnlineStore.Models.View;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private const int PageSize = 5;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult Index(int? id, int page = 1)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            Product? product = _productService.GetProductById((int)id);
            if (product == null)
                return RedirectToAction("Index", "Home");

            var reviews = _productService.GetReviewsPaged(product.Id, page, PageSize);
            var totalReviews = _productService.GetTotalReviewCount(product.Id);

            var model = new ProductReviewViewModel
            {
                Product = product,
                Reviews = reviews,
                NewReview = new Review { ProductId = product.Id },
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalReviews / (double)PageSize)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddReview([FromForm] ProductReviewViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "Для добавления отзыва необходимо войти в систему.";
                return RedirectToAction("Index", new { id = model.NewReview.ProductId });
            }

            Review review = model.NewReview;

            if (!string.IsNullOrWhiteSpace(review.Author) && !string.IsNullOrWhiteSpace(review.Content))
            {
                _productService.AddReview(review);
            }

            return RedirectToAction("Index", new { id = review.ProductId });
        }

    }
}
