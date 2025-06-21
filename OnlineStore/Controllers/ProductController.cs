using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.Domain;
using OnlineStore.Models.View;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("{controller}/{action}/{id:int?}")]
        public IActionResult Index(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");

            Product? product = _productService.GetProductById((int)id);

            if (product == null)
                return RedirectToAction("Index", "Home");

            var reviews = _productService.GetReviewsByProductId(product.Id);

            var model = new ProductReviewViewModel
            {
                Product = product,
                Reviews = reviews,
                NewReview = new Review { ProductId = product.Id }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddReview([FromForm] ProductReviewViewModel model)
        {
            Review review = model.NewReview;

            if (!string.IsNullOrWhiteSpace(review.Author) && !string.IsNullOrWhiteSpace(review.Content))
            {
                _productService.AddReview(review);
            }

            return RedirectToAction("Index", new { id = review.ProductId });
        }


    }
}
