using Application.DTOs;
using Domain;


namespace Domain.Interfaces;

public interface IWarehouseService
{
    public List<Warehouse> GetAllWarehouses();
    public Warehouse CreateNewWarehouse(PostWarehouseDTO dto);
    public Warehouse GetWarehouseById(int id);
    public Warehouse UpdateWarehouse(int id, PutWarehouseDTO dto);
    public Warehouse DeleteWarehouse(int id);
}
