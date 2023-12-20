using Application.DTOs;
using Domain;


namespace Domain.Interfaces;

public interface IWarehouseService
{
    public List<Warehouse> GetAll();
    public Warehouse Create(PostWarehouseDTO dto);
    public Warehouse GetById(int id);
    public Warehouse Update(int id, PutWarehouseDTO dto);
    public Warehouse Delete(int id);

    public List<Product> GetProducts(int warehouseId);
    public Product CreateProduct(int warehouseId,PostProductDTOWithQuantity productDTO);
    public Product UpdateProduct(int warehouseId, PutProductDTOWithQuantity productDTO);
    public Product DeleteProduct(int warehouseId, int productId, bool deleteFromProductTable);
    public Product AddProduct(PostProductInWarehouseDTO pinDTO);

    public List<User> GetUsers(int warehouseId);
    public User AddUser(PostUserInWarehouseDTO uiwDTO);
    public User RemoveUser(int warehouseId, int userId);
    public User UpdateUserAccessLevel(PutUserInWarehouseDTO uiwDTO);
}
