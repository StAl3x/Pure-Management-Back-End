using Application.DTOs;
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
        public List<Warehouse> GetAll();
        public Warehouse Create(Warehouse warehouse);
        public Warehouse GetById(int id);
        public Warehouse Update(Warehouse dto);
        public Warehouse Delete(int id);

        //Product in warehouse manipulation
        public List<Product> GetProducts(int warehouseId);
        public Product CreateProduct(int warehouseId, Product product);
        public Product UpdateProduct(int warehouseId, Product product);
        public Product DeleteProduct(int warehouseId, int productId, bool deleteFromProductTable);
        public Product AddProduct(ProductInWarehouse pin);

        // User in warehouse manipulation

        public List<User> GetUsers(int warehouseId);
        public User AddUser (UserInWarehouse uiw);
        public User RemoveUser (int userId);
        public User UpdateUserAccesLevel(UserInWarehouse uiw);
    }
}
