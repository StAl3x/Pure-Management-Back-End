using Application.DTOs;
using Application.Interfaces;
using Domain;


namespace Infrastructure 
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AppDbContext _context;

        public WarehouseRepository(AppDbContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public List<Warehouse> GetAll()
        {
            return _context.WarehouseTable.ToList();
        }

        public Warehouse GetById(int id)
        {
            return _context.WarehouseTable.Find(id) ?? throw new KeyNotFoundException();
        }
        public Warehouse Create(Warehouse warehouse)
        {
            _context.WarehouseTable.Add(warehouse);
            _context.SaveChanges();
            return warehouse;
        }

        public Warehouse Update(Warehouse warehouse)
        {
            _context.WarehouseTable.Update(warehouse);
            _context.SaveChanges();
            return warehouse;
        }

        public Warehouse Delete(int id)
        {
            var warehouseToDelete = _context.WarehouseTable.Find(id) ?? throw new KeyNotFoundException();
            _context.WarehouseTable.Remove(warehouseToDelete);
            _context.SaveChanges();
            return warehouseToDelete;
        }

        public List<Product> GetProducts(int warehouseId)
        {
            List<ProductInWarehouse> productsInWarehouse = _context.ProductWarehouseTable.Where(p => p.WarehouseId == warehouseId).ToList();
            List<Product> products = new List<Product>();
            foreach (ProductInWarehouse pin in productsInWarehouse)
            {
                Product resultProduct = _context.ProductTable.Find(pin.ProductId) ?? throw new KeyNotFoundException();
                Product productWithQuantity = new Product() { Name = resultProduct.Name, CompanyId = resultProduct.CompanyId, Unit = resultProduct.Unit, PricePerUnit = resultProduct.PricePerUnit, Quantity = pin.Quantity };
                products.Add(productWithQuantity);
            }
            return products;

        }
        public Product CreateProduct(ProductInWarehouse pin, Product product)
        {
            _context.ProductWarehouseTable.Add(pin);
            _context.ProductTable.Add(product);
            _context.SaveChanges();
            Product result = new Product() { Name = product.Name, Unit = product.Unit, PricePerUnit = product.PricePerUnit, CompanyId = product.CompanyId, Quantity = pin.Quantity};
            return result;
        }

        public Product UpdateProduct(ProductInWarehouse pin, Product product)
        {
            _context.ProductWarehouseTable.Update(pin);
            _context.ProductTable.Update(product);
            _context.SaveChanges();
            Product result = new Product() { Name = product.Name, Unit = product.Unit, PricePerUnit = product.PricePerUnit, CompanyId = product.CompanyId, Quantity = pin.Quantity };
            return result;
        }

        public Product DeleteProduct(int id, bool deleteFromProductTable)
        {
            ProductInWarehouse pin = (ProductInWarehouse)_context.ProductWarehouseTable.Where(p => p.ProductId == id);
            _context.ProductWarehouseTable.Remove(pin);
            Product productToDelete = _context.ProductTable.Find(id) ?? throw new KeyNotFoundException();
            if (deleteFromProductTable)
            {
                _context.ProductTable.Remove(productToDelete);
            }
            _context.SaveChanges();
            return new Product() { Name = productToDelete.Name, Unit = productToDelete.Unit, PricePerUnit = productToDelete.PricePerUnit, CompanyId = productToDelete.CompanyId, Quantity = pin.Quantity };
        }

        public Product AddProduct(ProductInWarehouse pin)
        {
            _context.ProductWarehouseTable.Add(pin);
            _context.SaveChanges();
            Product product = _context.ProductTable.Find(pin.ProductId) ?? throw new KeyNotFoundException();
            return new Product() { Name = product.Name, Unit = product.Unit, PricePerUnit = product.PricePerUnit, CompanyId = product.CompanyId, Quantity = pin.Quantity };
        }

        public List<User> GetUsers(int warehouseId)
        {
            List<UserInWarehouse> usersInWarehouse = _context.UserWarehouseTable.Where(uiw => uiw.WarehouseId == warehouseId).ToList();
            List<User> users = new List<User>();
            foreach (UserInWarehouse uiw in usersInWarehouse)
            {
                User resultUser = _context.UserTable.Find(uiw.UserId) ?? throw new KeyNotFoundException();
                users.Add(resultUser);
            }
            return users;
        }

        public User AddUser(UserInWarehouse uiw)
        {
            _context.UserWarehouseTable.Add(uiw);
            _context.SaveChanges();
            return _context.UserTable.Find(uiw.UserId) ?? throw new KeyNotFoundException();
            
        }

        public User RemoveUser(int userId)
        {
            User user = _context.UserTable.Find(userId) ?? throw new KeyNotFoundException();
            UserInWarehouse uiwToDelete = (UserInWarehouse) _context.UserWarehouseTable.Where(uiw => uiw.UserId == userId).First();
            _context.UserWarehouseTable.Remove(uiwToDelete);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUserAccesLevel(UserInWarehouse uiw)
        {
            _context.UserWarehouseTable.Update(uiw);
            _context.SaveChanges();
            return _context.UserTable.Find(uiw.UserId) ?? throw new KeyNotFoundException();
        }
    }
}
