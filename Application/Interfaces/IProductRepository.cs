using Domain;

namespace Application.Interfaces;

public interface IProductRepository
{
    public List<Product> GetAllProducts();
    public Product CreateNewProduct(Product product, int userId);
    public Product GetProductById(int id);
    public Product UpdateProduct(Product product, int userId);
    public Product DeleteProduct(int id, int userId);
}
