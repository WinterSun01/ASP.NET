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
    }
}
