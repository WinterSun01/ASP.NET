using Microsoft.Data.SqlClient;
using OnlineStore.Models.Domain;

namespace OnlineStore.Data
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _connectionString;

        public ReviewRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Review> GetByProductId(int productId)
        {
            var reviews = new List<Review>();
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("SELECT Id, ProductId, Author, Content FROM Reviews WHERE ProductId = @productId", connection);
            command.Parameters.AddWithValue("@productId", productId);

            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                reviews.Add(new Review
                {
                    Id = reader.GetInt32(0),
                    ProductId = reader.GetInt32(1),
                    Author = reader.GetString(2),
                    Content = reader.GetString(3)
                });
            }

            return reviews;
        }

        public void Add(Review review)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("INSERT INTO Reviews (ProductId, Author, Content) VALUES (@ProductId, @Author, @Content)", connection);
            command.Parameters.AddWithValue("@ProductId", review.ProductId);
            command.Parameters.AddWithValue("@Author", review.Author);
            command.Parameters.AddWithValue("@Content", review.Content);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
