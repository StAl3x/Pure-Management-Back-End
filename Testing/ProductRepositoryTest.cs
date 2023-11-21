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


}