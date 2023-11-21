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
        moqRepository.Setup(r => r.GetWarehouseById(moqId)).Returns(testWarehouse);


        var mapper = new MapperConfiguration(c => { c.CreateMap<PostWarehouseDTO, Warehouse>(); }).CreateMapper();
        var postValidator = new PostWarehouseValidator();
        var putValidator = new PutWarehouseValidator();
        IWarehouseService warehouseService = new WarehouseService(moqRepository.Object,postValidator,putValidator, mapper);

        Warehouse response = warehouseService.GetWarehouseById(moqId);
        

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
        moqRepository.Setup(r => r.GetAllWarehouses()).Returns(moqWarehouses);


        var mapper = new MapperConfiguration(c => { c.CreateMap<PostProductDTO, Product>(); }).CreateMapper();
        var postValidator = new PostWarehouseValidator();
        var putValidator = new PutWarehouseValidator();
        IWarehouseService warehouseService = new WarehouseService(moqRepository.Object, postValidator, putValidator, mapper);

        List<Warehouse> response = warehouseService.GetAllWarehouses();


        Assert.IsNotNull(response);
        Assert.AreEqual(response, moqWarehouses);
        Assert.IsTrue(response is List<Warehouse>);
        Assert.AreEqual(response.Count, moqWarehouses.Count);
        Assert.AreEqual(response[0], moqWarehouses[0]);
        Assert.AreEqual(response[1], moqWarehouses[1]);
        moqRepository.Verify(r => r.GetAllWarehouses(), Times.Once);
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

        moqRepository.Setup(r => r.GetWarehouseById(moqId)).Returns(warehouseOne);
        moqRepository.Setup(r => r.DeleteWarehouse(moqId)).Returns(() => { warehouseList.Remove(warehouseOne); 
                                                                         return warehouseOne; });


        var mapper = new MapperConfiguration(c => { c.CreateMap<PostWarehouseDTO, Warehouse>(); }).CreateMapper();
        var postValidator = new PostWarehouseValidator();
        var putValidator = new PutWarehouseValidator();
        IWarehouseService warehouseService = new WarehouseService(moqRepository.Object, postValidator, putValidator, mapper);

        Warehouse response = warehouseService.DeleteWarehouse(moqId);


        Assert.IsNotNull(response);
        Assert.AreEqual(response, warehouseOne);
        Assert.IsTrue(response is Warehouse);
        Assert.AreEqual(warehouseOne.Id, response.Id);
        Assert.IsFalse(warehouseList.Contains(warehouseOne));
        Assert.IsTrue(warehouseList.Contains(warehouseTwo));
        moqRepository.Verify(r => r.DeleteWarehouse(moqId), Times.Once);
    }

    [TestMethod]
    public void UpdateWarehouse()
    {
        var moqRepository = new Mock<IWarehouseRepository>();
        int moqId = 1;
        PutWarehouseDTO putDto = new PutWarehouseDTO() { Address = "Esbjerg 6700", CompanyId = 2, EmailAddress = "6700@gmail.com", Name = "updatedWarehouse", };
        Warehouse updatedWarehouse = new Warehouse() { Id = moqId, Address = putDto.Address, CompanyId = putDto.CompanyId, EmailAddress = putDto.EmailAddress, Name = putDto.Name};

        moqRepository.Setup(r => r.UpdateWarehouse(It.IsAny<Warehouse>())).Returns(updatedWarehouse);
       


        var mapper = new MapperConfiguration(c => { 
            c.CreateMap<PostWarehouseDTO, Warehouse>();
            c.CreateMap<PutWarehouseDTO, Warehouse>();
        }).CreateMapper();
        var postValidator = new PostWarehouseValidator();
        var putValidator = new PutWarehouseValidator();
        IWarehouseService warehouseService = new WarehouseService(moqRepository.Object, postValidator, putValidator, mapper);

        Warehouse response = warehouseService.UpdateWarehouse(moqId, putDto);


        Assert.IsNotNull(response);
        Assert.IsTrue(response is Warehouse);
        Assert.AreEqual(updatedWarehouse.Name, response.Name);
        Assert.AreEqual(updatedWarehouse.Address, response.Address);
        Assert.AreEqual(updatedWarehouse.CompanyId, response.CompanyId);
        Assert.AreEqual(updatedWarehouse.EmailAddress, response.EmailAddress);
        Assert.AreEqual(updatedWarehouse.Id, moqId);
        moqRepository.Verify(r => r.UpdateWarehouse(It.IsAny<Warehouse>()), Times.Once);
    }

}