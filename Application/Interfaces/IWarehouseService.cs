using Domain;
using Domain.DTOs;
using Domain.Models;


namespace Domain.Interfaces;

public interface IWarehouseService
{
    public List<Warehouse> GetAll(int userId);
    public Warehouse Create(WarehouseModel model);
    public Warehouse GetById(int id);
    public Warehouse Update(int id, WarehouseModel model);
    public Warehouse Delete(int id, int userId);

    public List<Product> GetProducts(int warehouseId);
    public Product CreateProduct(int warehouseId,ProductModel model);
    public Product UpdateProduct(int warehouseId, ProductModel model);
    public Product DeleteProduct(int warehouseId, DeleteProductFromWarehouseModel model);
    public Product AddProduct(PostProductInWarehouseDTO pinDTO, int userId);

    public List<User> GetUsers(int warehouseId);
    public User AddUser(PostUserInWarehouseDTO uiwDTO, int userId);
    public User RemoveUser(int warehouseId, int userId);
    public User UpdateUserAccessLevel(PutUserInWarehouseDTO uiwDTO, int userId);
}
