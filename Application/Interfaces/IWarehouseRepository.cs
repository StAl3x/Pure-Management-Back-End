using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWarehouseRepository
    {
        public List<Warehouse> GetAllWarehouses();
        public Warehouse CreateNewWarehouse(Warehouse warehouse);
        public Warehouse GetWarehouseById(int id);
        public Warehouse UpdateWarehouse(Warehouse dto);
        public Warehouse DeleteWarehouse(int id);
    }
}
