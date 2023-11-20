using Application.Interfaces;
using Domain;


namespace Infrastructure 
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AppDbContext _context;

        public WarehouseRepository(AppDbContext context) 
        {
            _context = context;
        }
        public List<Warehouse> GetAllWarehouses()
        {
            return _context.WarehouseTable.ToList();
        }

        public Warehouse GetWarehouseById(int id)
        {
            return _context.WarehouseTable.Find(id) ?? throw new KeyNotFoundException();
        }
        public Warehouse CreateNewWarehouse(Warehouse warehouse)
        {
            _context.WarehouseTable.Add(warehouse);
            _context.SaveChanges();
            return warehouse;
        }

        public Warehouse UpdateWarehouse(Warehouse warehouse)
        {
            _context.WarehouseTable.Update(warehouse);
            _context.SaveChanges();
            return warehouse;
        }

        public Warehouse DeleteWarehouse(int id)
        {
            var warehouseToDelete = _context.WarehouseTable.Find(id) ?? throw new KeyNotFoundException();
            _context.WarehouseTable.Remove(warehouseToDelete);
            _context.SaveChanges();
            return warehouseToDelete;
        }


    }
}
