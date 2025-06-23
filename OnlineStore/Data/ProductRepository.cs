using Microsoft.Data.SqlClient;
using OnlineStore.Models.Domain;
using System.Data;

namespace OnlineStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Product> GetAll()
        {
            var products = new List<Product>();
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("SELECT Id, Name FROM Products", connection);

            connection.Open();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            return products;
        }

        public Product? GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("SELECT Id, Name FROM Products WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
            }

            return null;
        }

        public List<Product> GetProductsPaged(int page, int pageSize)
        {
            var products = new List<Product>();

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = @"SELECT Id, Name
                                 FROM Products
                                 ORDER BY Id
                                 OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Offset", (page - 1) * pageSize);
                command.Parameters.AddWithValue("@PageSize", pageSize);

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

        public int GetTotalProductCount()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM Products";
                var command = new SqlCommand(query, connection);

                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }
    }
}
