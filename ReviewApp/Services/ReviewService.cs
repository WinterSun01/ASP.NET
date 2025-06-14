using ReviewApp.Models;

namespace ReviewApp.Services
{
    public class ReviewService
    {
        private readonly List<Review> _reviews = new();

        public void AddReview(Review review)
        {
            _reviews.Add(review);
            Console.WriteLine($"Review added: {review.Author}, Total reviews: {_reviews.Count}");
        }

        public List<Review> GetLastReviews(int count)
        {
            return _reviews
                .TakeLast(count)
                .ToList();
        }
    }
}
