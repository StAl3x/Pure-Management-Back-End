using Application.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWarehouseService
    {
        public List<Warehouse> GetAllWarehouse();
        public Warehouse CreateNewWarehouse(PostWarehouseDTO dto);
        public Warehouse GetWarehouseById(int id);
        public Warehouse UpdateWarehouse(int id, Warehouse warehouse);
        public Warehouse DeleteWarehouse(int id);
    }
}
