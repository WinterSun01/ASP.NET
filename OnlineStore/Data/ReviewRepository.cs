using OnlineStore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Review> GetByProductId(int productId)
        {
            return _context.Reviews
                .Where(r => r.ProductId == productId)
                .OrderBy(r => r.Id)
                .ToList();
        }

        public void Add(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }

        public List<Review> GetReviewsPaged(int productId, int page, int pageSize)
        {
            return _context.Reviews
                .Where(r => r.ProductId == productId)
                .OrderBy(r => r.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int GetTotalReviewCount(int productId)
        {
            return _context.Reviews
                .Count(r => r.ProductId == productId);
        }
    }
}
