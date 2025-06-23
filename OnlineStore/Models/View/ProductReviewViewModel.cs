using OnlineStore.Models.Domain;

namespace OnlineStore.Models.View
{
    public class ProductReviewViewModel
    {
        public Product? Product { get; set; }
        public List<Review>? Reviews { get; set; }
        public Review NewReview { get; set; } = new Review();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
