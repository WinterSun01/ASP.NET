using OnlineStore.Data;
using OnlineStore.Models.Domain;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;

        public ProductService(IProductRepository productRepo, IReviewRepository reviewRepo)
        {
            _productRepository = productRepo;
            _reviewRepository = reviewRepo;
        }

        public List<Product> GetProducts() => _productRepository.GetAll();

        public Product? GetProductById(int id) => _productRepository.GetById(id);

        public void AddReview(Review review) => _reviewRepository.Add(review);

        public List<Review> GetReviewsByProductId(int productId) => _reviewRepository.GetByProductId(productId);
    }
}
