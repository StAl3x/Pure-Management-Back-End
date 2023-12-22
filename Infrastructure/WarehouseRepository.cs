using Domain.DTOs;
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
        public List<Warehouse> GetAll(int userId)
        {
            UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
            if (uiw.AccessLevel != 4)
            {
                throw new Exception("Access denied");
            }
            return _context.WarehouseTable.ToList();
        }

        public Warehouse GetById(int id)
        {
            return _context.WarehouseTable.Find(id) ?? throw new KeyNotFoundException();
        }
        public Warehouse Create(Warehouse warehouse, int userId)
        {
            UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
            if (uiw.AccessLevel != 4)
            {
                throw new Exception("Access denied");
            }
            _context.WarehouseTable.Add(warehouse);
            _context.SaveChanges();
            return warehouse;
        }

        public Warehouse Update(Warehouse warehouse, int userId)
        {
            UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
            if (uiw.AccessLevel != 4)
            {
                throw new Exception("Access denied");
            }
            _context.WarehouseTable.Update(warehouse);
            _context.SaveChanges();
            return warehouse;
        }

        public Warehouse Delete(int id, int userId)
        {
            UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
            if (uiw.AccessLevel != 4)
            {
                throw new Exception("Access denied");
            }
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
        public Product CreateProduct(int warehouseId,Product product, int userId)
        {
            UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
            if (uiw.AccessLevel != 4)
            {
                throw new Exception("Access denied");
            }

            _context.ProductTable.Add(product);
            _context.SaveChanges();
            int productId  = _context.ProductTable.Where(p => p.Name == product.Name && p.CompanyId == product.CompanyId).Select(p => p.Id).FirstOrDefault();
            _context.ProductWarehouseTable.Add(new ProductInWarehouse {ProductId = productId,WarehouseId= warehouseId,Quantity = product.Quantity });
            _context.SaveChanges();
            return _context.ProductTable.Find(productId) ?? throw new KeyNotFoundException();
        }

        public Product UpdateProduct(int warehouseId, Product product, int userId)
        {
            UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
            if (uiw.AccessLevel != 4)
            {
                throw new Exception("Access denied");
            }

            _context.ProductWarehouseTable.Update(new ProductInWarehouse { ProductId = product.Id, WarehouseId = warehouseId, Quantity = product.Quantity });
            _context.SaveChanges();
            return _context.ProductTable.Find(product.Id) ?? throw new KeyNotFoundException();
        }

        public Product DeleteProduct(int warehouseId, int productId, bool deleteFromProductTable, int userId)
        {
            UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
            if (uiw.AccessLevel != 4)
            {
                throw new Exception("Access denied");
            }
            ProductInWarehouse pin = _context.ProductWarehouseTable.Where(p => p.ProductId == productId && p.WarehouseId == warehouseId).FirstOrDefault() ?? throw new KeyNotFoundException();
            _context.ProductWarehouseTable.Remove(pin);
            Product productToDelete = _context.ProductTable.Find(productId) ?? throw new KeyNotFoundException();
            if (deleteFromProductTable)
            {
                _context.ProductTable.Remove(productToDelete);
            }
            _context.SaveChanges();
            return new Product() { Name = productToDelete.Name, Unit = productToDelete.Unit, PricePerUnit = productToDelete.PricePerUnit, CompanyId = productToDelete.CompanyId, Quantity = pin.Quantity };
        }

        public Product AddProduct(ProductInWarehouse pin, int userId)
        {
            UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
            if (uiw.AccessLevel != 4)
            {
                throw new Exception("Access denied");
            }
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

        public User AddUser(UserInWarehouse uiw, int userId)
        {
            UserInWarehouse requestUiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
            if (uiw.AccessLevel != 4)
            {
                throw new Exception("Access denied");
            }
            _context.UserWarehouseTable.Add(uiw);
            _context.SaveChanges();
            return _context.UserTable.Find(uiw.UserId) ?? throw new KeyNotFoundException();
            
        }

        public User RemoveUser(int warehouseId, int userId)
        {
            User user = _context.UserTable.Find(userId) ?? throw new KeyNotFoundException();
            UserInWarehouse uiwToDelete = (UserInWarehouse) _context.UserWarehouseTable.Where(uiw => uiw.UserId == userId && uiw.WarehouseId == warehouseId).First();
            _context.UserWarehouseTable.Remove(uiwToDelete);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUserAccesLevel(UserInWarehouse uiw, int userId)
        {
            UserInWarehouse requestUiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
            if (requestUiw.AccessLevel != 4)
            {
                throw new Exception("Access denied");
            }
            _context.UserWarehouseTable.Update(uiw);
            _context.SaveChanges();
            return _context.UserTable.Find(uiw.UserId) ?? throw new KeyNotFoundException();
        }
    }
}
