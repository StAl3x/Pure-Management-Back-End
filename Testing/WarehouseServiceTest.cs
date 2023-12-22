using Application;
using Domain.DTOs;
using Application.Validators;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using Moq;
using Infrastructure;
using Application.Interfaces;
using FluentValidation;


namespace Test;

[TestClass]

public class WarehouseServiceTest
{

    [TestMethod]
    public void GetWarehouseById()
    {
        var moqRepository = new Mock <IWarehouseRepository>();
        int moqId = 1;
        Warehouse testWarehouse = new()
        {
            Id = moqId
        };
        moqRepository.Setup(r => r.GetById(moqId)).Returns(testWarehouse);


        var mapper = new MapperConfiguration(c => { c.CreateMap<PostWarehouseDTO, Warehouse>(); }).CreateMapper();
        var postPinValidator = new PostProductInWarehouseValidator();
        var putPinValidator = new PutProductInWarehouseValidator();
        var postProductValidator = new PostProductValidator();
        var putProductValidator = new PutProductValidator();
        var postWarehouseValidator = new PostWarehouseValidator();
        var putWarehouseValidator = new PutWarehouseValidator();
        var postUIWValidator = new PostUserInWarehouseValidator();
        var putUIWValidator = new PutUserInWarehouseValidator();
        IWarehouseService warehouseService = new WarehouseService(moqRepository.Object, postWarehouseValidator, putWarehouseValidator, postProductValidator, putProductValidator, postPinValidator, putPinValidator, postUIWValidator, putUIWValidator, mapper);

        Warehouse response = warehouseService.GetById(moqId);
        

        Assert.IsNotNull(response);
        Assert.IsNotNull(response.Id);
        Assert.AreEqual(moqId, response.Id);
    }

    [TestMethod]
    public void GetAllWarehouses() 
    {
        var moqRepository = new Mock<IWarehouseRepository>();
        List<Warehouse> moqWarehouses = new()
        {
            new Warehouse { Id = 24 },
            new Warehouse { Id = 46 },
        };
        moqRepository.Setup(r => r.GetAll()).Returns(moqWarehouses);


        var mapper = new MapperConfiguration(c => { c.CreateMap<PostProductDTO, Product>(); }).CreateMapper();
        var postPinValidator = new PostProductInWarehouseValidator();
        var putPinValidator = new PutProductInWarehouseValidator();
        var postProductValidator = new PostProductValidator();
        var putProductValidator = new PutProductValidator();
        var postWarehouseValidator = new PostWarehouseValidator();
        var putWarehouseValidator = new PutWarehouseValidator();
        var postUIWValidator = new PostUserInWarehouseValidator();
        var putUIWValidator = new PutUserInWarehouseValidator();
        IWarehouseService warehouseService = new WarehouseService(moqRepository.Object, postWarehouseValidator, putWarehouseValidator, postProductValidator, putProductValidator, postPinValidator, putPinValidator, postUIWValidator, putUIWValidator, mapper);

        List<Warehouse> response = warehouseService.GetAll();


        Assert.IsNotNull(response);
        Assert.AreEqual(response, moqWarehouses);
        Assert.IsTrue(response is List<Warehouse>);
        Assert.AreEqual(response.Count, moqWarehouses.Count);
        Assert.AreEqual(response[0], moqWarehouses[0]);
        Assert.AreEqual(response[1], moqWarehouses[1]);
        moqRepository.Verify(r => r.GetAll(), Times.Once);
    }

    [TestMethod]
    public void DeleteProduct()
    {
        var moqRepository = new Mock<IWarehouseRepository>();
        int moqId = 1;
        Warehouse warehouseOne = new Warehouse { Id = 1, Name = "warehouseOne", Address= "Esbjerg 6705", CompanyId = 1, EmailAddress = "6705@gmail.com" };
        Warehouse warehouseTwo = new Warehouse { Id = 2, Name = "warehouseTwo", Address = "Esbjerg 6700", CompanyId = 2, EmailAddress = "6700@gmail.com" };
        List<Warehouse> warehouseList = new List<Warehouse>();
        warehouseList.Add(warehouseOne);
        warehouseList.Add(warehouseTwo);

        moqRepository.Setup(r => r.GetById(moqId)).Returns(warehouseOne);
        moqRepository.Setup(r => r.Delete(moqId)).Returns(() => { warehouseList.Remove(warehouseOne); 
                                                                         return warehouseOne; });


        var mapper = new MapperConfiguration(c => { c.CreateMap<PostWarehouseDTO, Warehouse>(); }).CreateMapper();
        var postPinValidator = new PostProductInWarehouseValidator();
        var putPinValidator = new PutProductInWarehouseValidator();
        var postProductValidator = new PostProductValidator();
        var putProductValidator = new PutProductValidator();
        var postWarehouseValidator = new PostWarehouseValidator();
        var putWarehouseValidator = new PutWarehouseValidator();
        var postUIWValidator = new PostUserInWarehouseValidator();
        var putUIWValidator = new PutUserInWarehouseValidator();
        IWarehouseService warehouseService = new WarehouseService(moqRepository.Object, postWarehouseValidator, putWarehouseValidator, postProductValidator, putProductValidator, postPinValidator, putPinValidator, postUIWValidator, putUIWValidator, mapper);

        Warehouse response = warehouseService.Delete(moqId);


        Assert.IsNotNull(response);
        Assert.AreEqual(response, warehouseOne);
        Assert.IsTrue(response is Warehouse);
        Assert.AreEqual(warehouseOne.Id, response.Id);
        Assert.IsFalse(warehouseList.Contains(warehouseOne));
        Assert.IsTrue(warehouseList.Contains(warehouseTwo));
        moqRepository.Verify(r => r.Delete(moqId), Times.Once);
    }

    [TestMethod]
    public void UpdateWarehouse()
    {
        var moqRepository = new Mock<IWarehouseRepository>();
        int moqId = 1;
        PutWarehouseDTO putDto = new PutWarehouseDTO() { Address = "Esbjerg 6700", CompanyId = 2, EmailAddress = "6700@gmail.com", Name = "updatedWarehouse", };
        Warehouse updatedWarehouse = new Warehouse() { Id = moqId, Address = putDto.Address, CompanyId = putDto.CompanyId, EmailAddress = putDto.EmailAddress, Name = putDto.Name};

        moqRepository.Setup(r => r.Update(It.IsAny<Warehouse>())).Returns(updatedWarehouse);
       


        var mapper = new MapperConfiguration(c => { 
            c.CreateMap<PostWarehouseDTO, Warehouse>();
            c.CreateMap<PutWarehouseDTO, Warehouse>();
        }).CreateMapper();
        var postPinValidator = new PostProductInWarehouseValidator();
        var putPinValidator = new PutProductInWarehouseValidator();
        var postProductValidator = new PostProductValidator();
        var putProductValidator = new PutProductValidator();
        var postWarehouseValidator = new PostWarehouseValidator();
        var putWarehouseValidator = new PutWarehouseValidator();
        var postUIWValidator = new PostUserInWarehouseValidator();
        var putUIWValidator = new PutUserInWarehouseValidator();
        IWarehouseService warehouseService = new WarehouseService(moqRepository.Object, postWarehouseValidator, putWarehouseValidator, postProductValidator, putProductValidator, postPinValidator, putPinValidator, postUIWValidator, putUIWValidator, mapper);

        Warehouse response = warehouseService.Update(moqId, putDto);


        Assert.IsNotNull(response);
        Assert.IsTrue(response is Warehouse);
        Assert.AreEqual(updatedWarehouse.Name, response.Name);
        Assert.AreEqual(updatedWarehouse.Address, response.Address);
        Assert.AreEqual(updatedWarehouse.CompanyId, response.CompanyId);
        Assert.AreEqual(updatedWarehouse.EmailAddress, response.EmailAddress);
        Assert.AreEqual(updatedWarehouse.Id, moqId);
        moqRepository.Verify(r => r.Update(It.IsAny<Warehouse>()), Times.Once);
    }

    [TestMethod]
    public void GetProducts()
    {
        var moqWarehouseRepository = new Mock<IWarehouseRepository>();
        Warehouse warehouse = new Warehouse() { Id = 1};
        List<ProductInWarehouse> moqPins = new List<ProductInWarehouse>()
        {
            new ProductInWarehouse { Id = 1, ProductId = 1, Quantity= 12, WarehouseId= 1 },
            new ProductInWarehouse { Id = 2, ProductId = 2, Quantity= 23, WarehouseId= 1 },
            new ProductInWarehouse { Id = 3, ProductId = 3, Quantity= 4, WarehouseId= 2 }
        };

        List<Product> moqProducts = new List<Product>()
        { 
            new Product {Id=1, Name= "product1", CompanyId = 1, Unit= "pieces", PricePerUnit = 12.33 , Quantity=12},
            new Product {Id=2, Name= "product2", CompanyId = 1, Unit= "pieces", PricePerUnit = 99, Quantity=23},
            new Product {Id=3, Name= "product3", CompanyId = 1, Unit= "pieces", PricePerUnit = 4, Quantity=4}
        };

        moqWarehouseRepository.Setup(r => r.CreateProduct(moqPins[0], moqProducts[0]));
        moqWarehouseRepository.Setup(r => r.CreateProduct(moqPins[1], moqProducts[1]));
        moqWarehouseRepository.Setup(r => r.CreateProduct(moqPins[2], moqProducts[2]));

        List<Product> expected = new List<Product>();
        expected.Add(moqProducts[0]);
        expected.Add(moqProducts[1]);
        moqWarehouseRepository.Setup(r => r.GetProducts(warehouse.Id)).Returns(expected);

        var mapper = new MapperConfiguration(c => { c.CreateMap<PostProductInWarehouseDTO, ProductInWarehouse>(); 
                                                    c.CreateMap<PostProductDTO, Product>(); })  
                                                    .CreateMapper();
        var postPinValidator = new PostProductInWarehouseValidator();
        var putPinValidator = new PutProductInWarehouseValidator();
        var postProductValidator = new PostProductValidator();
        var putProductValidator = new PutProductValidator();
        var postWarehouseValidator = new PostWarehouseValidator();
        var putWarehouseValidator = new PutWarehouseValidator();
        var postUIWValidator = new PostUserInWarehouseValidator();
        var putUIWValidator = new PutUserInWarehouseValidator();
        IWarehouseService warehouseService = new WarehouseService(moqWarehouseRepository.Object,postWarehouseValidator, putWarehouseValidator, postProductValidator, putProductValidator, postPinValidator, putPinValidator, postUIWValidator, putUIWValidator, mapper);

        List<Product> response = warehouseService.GetProducts(warehouse.Id);

        Assert.IsNotNull(response);
        Assert.IsTrue(response is List<Product>);
        Assert.AreEqual(response, expected);
        Assert.IsNotNull(response[0].Quantity);
        moqWarehouseRepository.Verify(r => r.GetProducts(warehouse.Id), Times.Once);

    }


}