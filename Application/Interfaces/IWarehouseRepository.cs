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
        public Product CreateProduct(ProductInWarehouse pin, Product product);
        public Product UpdateProduct(ProductInWarehouse pin, Product product);
        public Product DeleteProduct(int id, bool deleteFromProductTable);
        public Product AddProduct(ProductInWarehouse pin);
    }
}
