using Microsoft.EntityFrameworkCore;
using Domain;
using Infrastructure;
using Application.Interfaces;
using Moq;

namespace Test;

[TestClass]
public class ProductRepositoryTest
{
    [TestMethod]
    public void CreateProductRepository_WithNullDbContext() 
    {
        IProductRepository productRepo = null;

        var ex = Assert.ThrowsException<ArgumentNullException>(() => productRepo = new ProductRepository(null));

        Assert.AreEqual("Value cannot be null. (Parameter 'context')", ex.Message);
        Assert.IsNull(productRepo);
    }

    [TestMethod]
    public void CreateProductRepository_WithDbContext()
    {
        var moqDbContext = new Mock<AppDbContext>();

        IProductRepository response = new ProductRepository(moqDbContext.Object);

        Assert.IsTrue(response is ProductRepository);
        Assert.IsNotNull(response);
    }

    //[TestMethod]
    //public void GetProductById()
    //{
    //    var opts = new DbContextOptionsBuilder<AppDbContext>()
    //        .UseInMemoryDatabase(databaseName: "ProductDatabase")
    //        .Options;
            
        
    //    using (var context = new AppDbContext(opts)) 
    //    {
            
    //        context.Database.EnsureDeleted();
    //        context.Database.EnsureCreated();
    //        context.ProductTable.Add(new Product() {
    //            Id = 1,
    //            Name = "productOne",
    //            PricePerUnit = 12.33,
    //            Unit = "foot"
    //        });
    //        context.SaveChanges();

    //        IProductRepository productRepository = new ProductRepository(context);

    //        Product response = productRepository.GetProductById(1);

    //        Assert.AreEqual(response.Name, "productOne");
    //    }

        
    //}

}