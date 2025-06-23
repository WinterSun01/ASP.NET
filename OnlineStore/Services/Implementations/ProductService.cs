using Microsoft.Data.SqlClient;
using OnlineStore.Models.Domain;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Product> GetProducts()
        {
            var products = new List<Product>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Products";
                var command = new SqlCommand(query, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }

            return products;
        }

        public Product? GetProductById(int id)
        {
            Product? product = null;
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name FROM Products WHERE Id = @id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new Product
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                    }
                }
            }

            return product;
        }

        public void AddReview(Review review)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Reviews (ProductId, Author, Content) VALUES (@ProductId, @Author, @Content)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", review.ProductId);
                command.Parameters.AddWithValue("@Author", review.Author);
                command.Parameters.AddWithValue("@Content", review.Content);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Review> GetReviewsByProductId(int productId)
        {
            var reviews = new List<Review>();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, ProductId, Author, Content FROM Reviews WHERE ProductId = @ProductId";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
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
                }
            }

            return reviews;
        }
    }
}
