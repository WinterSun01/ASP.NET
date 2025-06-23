using OnlineStore.Models.Domain;

namespace OnlineStore.Data
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
        List<Product> GetProductsPaged(int page, int pageSize);
        int GetTotalProductCount();
    }
}
