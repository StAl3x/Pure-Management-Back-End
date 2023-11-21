using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Product> GetAllProducts()
    {
        return _context.ProductTable.ToList();
    }

    public Product CreateNewProduct(Product product)
    {
        _context.ProductTable.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Product GetProductById(int id)
    {
        return _context.ProductTable.Find(id) ?? throw new KeyNotFoundException();
    }

    public Product UpdateProduct(Product product)
    {
        _context.ProductTable.Update(product);
        _context.SaveChanges();
        return product;
    }

    public Product DeleteProduct(int id)
    {
        Product productToDelete = _context.ProductTable.Find(id) ?? throw new KeyNotFoundException();
        _context.ProductTable.Remove(productToDelete);
        _context.SaveChanges();
        return productToDelete;
    }
}