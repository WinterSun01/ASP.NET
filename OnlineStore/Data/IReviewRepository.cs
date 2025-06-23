using OnlineStore.Models.Domain;

namespace OnlineStore.Data
{
    public interface IReviewRepository
    {
        List<Review> GetByProductId(int productId);
        void Add(Review review);
    }
}
