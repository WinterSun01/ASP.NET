using OnlineStore.Data;
using OnlineStore.Models.Domain;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAll() => _context.Products.ToList();

    public Product? GetById(int id) => _context.Products.FirstOrDefault(p => p.Id == id);

    public List<Product> GetProductsPaged(int page, int pageSize)
    {
        return _context.Products
                       .OrderBy(p => p.Id)
                       .Skip((page - 1) * pageSize)
                       .Take(pageSize)
                       .ToList();
    }

    public int GetTotalProductCount() => _context.Products.Count();
}
