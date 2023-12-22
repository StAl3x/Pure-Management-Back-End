using Domain.DTOs;
using Domain.Models;

namespace Domain.Interfaces;

public interface IProductService
{
    public List<Product> GetAllProducts();
    public Product CreateNewProduct(ProductModel dto);
    public Product GetProductById(int id);
    public Product UpdateProduct(int productId, ProductModel model);
    public Product DeleteProduct(int id, int userId);
}