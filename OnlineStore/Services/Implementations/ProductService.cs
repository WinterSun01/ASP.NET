using OnlineStore.Models.Domain;
using OnlineStore.Services;

public class ProductService : IProductService
{
    private readonly List<Product> products = new List<Product>()
    {
        new Product() { Id = 0, Name = "Product 1" },
        new Product() { Id = 1, Name = "Product 2" },
        new Product() { Id = 2, Name = "Product 3" }
    };

    private readonly List<Review> reviews = new List<Review>();

    public List<Product> GetProducts()
    {
        return products;
    }

    public Product? GetProductById(int id)
    {
        foreach (Product product in products)
        {
            if (product.Id == id)
                return product;
        }

        return null;
    }

    public void AddReview(Review review)
    {
        reviews.Add(review);
    }
    public List<Review> GetReviewsByProductId(int productId)
    {
        return reviews.Where(r => r.ProductId == productId).ToList();
    }

}
