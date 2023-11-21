using Application;
using Application.DTOs;
using Application.Validators;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Moq;
using Infrastructure;
using Application.Interfaces;


namespace Test;

[TestClass]

public class ProductServiceTest
{

    [TestMethod]
    public void GetProductById()
    {
        var moqRepository = new Mock <IProductRepository>();
        int moqId = 1;
        Product testProduct = new()
        {
            Id = moqId
        };
        moqRepository.Setup(r => r.GetProductById(moqId)).Returns(testProduct);


        var mapper = new MapperConfiguration(c => { c.CreateMap<PostProductDTO, Product>(); }).CreateMapper();
        var postValidator = new PostProductValidator();
        var putValidator = new PutProductValidator();
        IProductService productService = new ProductService(moqRepository.Object,postValidator,putValidator, mapper);

        Product response = productService.GetProductById(moqId);
        

        Assert.IsNotNull(response);
        Assert.AreEqual(moqId, response.Id);
    }

    [TestMethod]
    public void GetAllProducts() 
    {
        var moqRepository = new Mock<IProductRepository>();
        List<Product> moqProducts = new()
        {
            new Product { Id = 24 },
            new Product { Id = 46 },
        };
        moqRepository.Setup(r => r.GetAllProducts()).Returns(moqProducts);


        var mapper = new MapperConfiguration(c => { c.CreateMap<PostProductDTO, Product>(); }).CreateMapper();
        var postValidator = new PostProductValidator();
        var putValidator = new PutProductValidator();
        IProductService productService = new ProductService(moqRepository.Object, postValidator, putValidator, mapper);

        List<Product> response = productService.GetAllProducts();


        Assert.IsNotNull(response);
        Assert.AreEqual(response, moqProducts);
        Assert.IsTrue(response is List<Product>);
        Assert.AreEqual(response.Count, moqProducts.Count);
        Assert.AreEqual(response[0], moqProducts[0]);
        Assert.AreEqual(response[1], moqProducts[1]);
        moqRepository.Verify(r => r.GetAllProducts(), Times.Once);
    }

    [TestMethod]
    public void DeleteProduct()
    {
        var moqRepository = new Mock<IProductRepository>();
        int moqId = 1;
        Product productOne = new Product { Id = 1, Name = "productOne", PricePerUnit = 12.23, Unit = "Piece" };
        Product productTwo = new Product { Id = 2, Name = "productTwo", PricePerUnit = 56, Unit = "meter" };
        List<Product> productList = new List<Product>();
        productList.Add(productOne);
        productList.Add(productTwo);

        moqRepository.Setup(r => r.GetProductById(moqId)).Returns(productOne);
        moqRepository.Setup(r => r.DeleteProduct(moqId)).Returns(() => { productList.Remove(productOne); 
                                                                         return productOne; });


        var mapper = new MapperConfiguration(c => { c.CreateMap<PostProductDTO, Product>(); }).CreateMapper();
        var postValidator = new PostProductValidator();
        var putValidator = new PutProductValidator();
        IProductService productService = new ProductService(moqRepository.Object, postValidator, putValidator, mapper);

        Product response = productService.DeleteProduct(moqId);


        Assert.IsNotNull(response);
        Assert.AreEqual(response, productOne);
        Assert.IsTrue(response is Product);
        Assert.AreEqual(productOne.Id, response.Id);
        Assert.IsFalse(productList.Contains(productOne));
        Assert.IsTrue(productList.Contains(productTwo));
        moqRepository.Verify(r => r.DeleteProduct(moqId), Times.Once);
    }

    [TestMethod]
    public void UpdateProduct()
    {
        var moqRepository = new Mock<IProductRepository>();
        int moqId = 1;
        PutProductDTO putDto = new PutProductDTO() {Name = "updatedProduct", PricePerUnit = 12.23, Unit="m2" };
        Product updatedProduct = new Product() { Id = moqId, Name = putDto.Name, PricePerUnit = (double)putDto.PricePerUnit, Unit = putDto.Unit };

        moqRepository.Setup(r => r.UpdateProduct(It.IsAny<Product>())).Returns(updatedProduct);
       


        var mapper = new MapperConfiguration(c => { 
            c.CreateMap<PostProductDTO, Product>();
            c.CreateMap<PutWarehouseDTO, Product>();
        }).CreateMapper();
        var postValidator = new PostProductValidator();
        var putValidator = new PutProductValidator();
        IProductService productService = new ProductService(moqRepository.Object, postValidator, putValidator, mapper);

        Product response = productService.UpdateProduct(moqId, putDto);


        Assert.IsNotNull(response);
        Assert.IsTrue(response is Product);
        Assert.AreEqual(updatedProduct.Name, response.Name);
        Assert.AreEqual(updatedProduct.PricePerUnit, response.PricePerUnit);
        Assert.AreEqual(updatedProduct.Unit, response.Unit);
        Assert.AreEqual(updatedProduct.Id, moqId);
        moqRepository.Verify(r => r.UpdateProduct(It.IsAny<Product>()), Times.Once);
    }

}