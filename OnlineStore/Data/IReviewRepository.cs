using OnlineStore.Models.Domain;

namespace OnlineStore.Data
{
    public interface IReviewRepository
    {
        List<Review> GetByProductId(int productId);
        void Add(Review review);

        List<Review> GetReviewsPaged(int productId, int page, int pageSize);
        int GetTotalReviewCount(int productId);

    }
}
