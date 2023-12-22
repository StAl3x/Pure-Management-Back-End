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
        public List<Warehouse> GetAll(int userId);
        public Warehouse Create(Warehouse warehouse, int userId);
        public Warehouse GetById(int id);
        public Warehouse Update(Warehouse dto, int userId);
        public Warehouse Delete(int id, int userId);

        //Product in warehouse manipulation
        public List<Product> GetProducts(int warehouseId);
        public Product CreateProduct(int warehouseId, Product product, int userId);
        public Product UpdateProduct(int warehouseId, Product product, int userId);
        public Product DeleteProduct(int warehouseId, int productId, bool deleteFromProductTable, int userId);
        public Product AddProduct(ProductInWarehouse pin, int userId);

        // User in warehouse manipulation

        public List<User> GetUsers(int warehouseId);
        public User AddUser (UserInWarehouse uiw, int userId);
        public User RemoveUser (int warehouseId, int userId);
        public User UpdateUserAccesLevel(UserInWarehouse uiw, int userId);
    }
}
