using OnlineStore.Data;
using OnlineStore.Models.Domain;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IReviewRepository _reviewRepository;

        public ProductService(IProductRepository productRepository, IReviewRepository reviewRepository)
        {
            _productRepository = productRepository;
            _reviewRepository = reviewRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetAll();
        }

        public Product? GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void AddReview(Review review)
        {
            _reviewRepository.Add(review);
        }

        public List<Review> GetReviewsByProductId(int productId)
        {
            return _reviewRepository.GetByProductId(productId);
        }

        public List<Product> GetProductsPaged(int page, int pageSize)
        {
            return _productRepository.GetProductsPaged(page, pageSize);
        }

        public int GetTotalProductCount()
        {
            return _productRepository.GetTotalProductCount();
        }

        public List<Review> GetReviewsPaged(int productId, int page, int pageSize)
        {
            return _reviewRepository.GetReviewsPaged(productId, page, pageSize);
        }

        public int GetTotalReviewCount(int productId)
        {
            return _reviewRepository.GetTotalReviewCount(productId);
        }
    }
}
