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
    public Product CreateProduct(PostProductInWarehouseDTO pin, PostProductDTO product);
    public Product UpdateProduct(PutProductInWarehouseDTO pin, PutProductDTO product);
    public Product DeleteProduct(int id, bool deleteFromProductTable);
    public Product AddProduct(PostProductInWarehouseDTO pinDTO);
}
