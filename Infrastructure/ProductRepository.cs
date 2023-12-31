﻿using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public List<Product> GetAllProducts()
    {
        return _context.ProductTable.ToList();
    }

    public Product GetProductById(int id)
    {
        return _context.ProductTable.Find(id) ?? throw new KeyNotFoundException();
    }

    public Product CreateNewProduct(Product product, int userId)
    {
        UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
        if (uiw.AccessLevel != 4)
            throw new Exception("Access Denied");
        _context.ProductTable.Add(product);
        _context.SaveChanges();
        return product;
    }

    public Product UpdateProduct(Product product, int userId)
    {
        UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
        if (uiw.AccessLevel != 4)
            throw new Exception("Access Denied");
        _context.ProductTable.Update(product);
        _context.SaveChanges();
        return product;
    }

    public Product DeleteProduct(int id, int userId)
    {
        UserInWarehouse uiw = _context.UserWarehouseTable.Where(u => u.UserId == userId).First() ?? throw new KeyNotFoundException();
        if (uiw.AccessLevel != 4)
            throw new Exception("Access Denied");
        Product productToDelete = _context.ProductTable.Find(id) ?? throw new KeyNotFoundException();
        _context.ProductTable.Remove(productToDelete);
        _context.SaveChanges();
        return productToDelete;
    }
}