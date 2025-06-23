using OnlineStore.Models.Domain;

namespace OnlineStore.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        void AddReview(Review review);
        List<Review> GetReviewsByProductId(int productId);
        List<Product> GetProductsPaged(int page, int pageSize);
        int GetTotalProductCount();
        List<Review> GetReviewsPaged(int productId, int page, int pageSize);
        int GetTotalReviewCount(int productId);
    }
}
