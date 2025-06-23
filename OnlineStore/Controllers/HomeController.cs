using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models.View;
using OnlineStore.Services;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private const int PageSize = 5;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int page = 1)
        {
            var products = _productService.GetProductsPaged(page, PageSize);
            var totalCount = _productService.GetTotalProductCount();

            var model = new HomePageViewModel
            {
                Products = products,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize)
            };

            return View(model);
        }
    }
}
