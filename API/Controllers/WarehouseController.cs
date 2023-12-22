using Domain.DTOs;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace API.Controllers;

[ApiController]
[Route("api/Warehouse")]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _warehouseService;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpGet]
    [Route("{userId}")]
    public ActionResult<List<Warehouse>> GetAllWarehouses([FromRoute] int userId)
    {
        try
        {
            return Ok(_warehouseService.GetAll(userId));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")] //localhost:5001/product/42
    public ActionResult<Warehouse> GetWarehouseById(int id)
    {
        try
        {
            return Ok(_warehouseService.GetById(id));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPost]
    [Route("")]
    public ActionResult<Warehouse> CreateNewWarehouse(WarehouseModel model)
    {
        try
        {
            var warehouse = _warehouseService.Create(model);
            return Ok(Created($"product/{warehouse.Id}", warehouse));
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.ToString());
        }
        catch (ArgumentException ex)
        {
            return StatusCode(403, ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }


    [HttpPut]
    [Route("{id}")] //localhost:5001/product/8732648732
    public ActionResult<Warehouse> UpdateWarehouse([FromRoute] int id, [FromBody] WarehouseModel model)
    {
        try
        {
            var result = _warehouseService.Update(id, model);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.ToString());
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }


    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Warehouse> DeleteWarehouse([FromRoute]int id, [FromBody] int userId)
    {
        try
        {
            return Ok(_warehouseService.Delete(id, userId));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpGet]
    [Route("product/{id}")]
    public ActionResult<List<Product>> GetProducts([FromRoute] int id) 
    {
        try
        {
            return Ok(_warehouseService.GetProducts(id));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPost]
    [Route("product/{warehouseId}")]
    public ActionResult<Product> CreateProduct([FromRoute] int warehouseId, [FromBody] ProductModel model) 
    {
        try
        {
            var result = _warehouseService.CreateProduct(warehouseId, model);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.ToString());
        }
        catch (ArgumentException ex)
        {
            return StatusCode(403, ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPut]
    [Route("productQuantity/{warehouseId}")]
    public ActionResult<Product> UpdateProductQuantity([FromRoute] int warehouseId, ProductModel model) 
    {
        try
        {
            return Ok(_warehouseService.UpdateProduct(warehouseId, model));
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.ToString());
        }
        catch (ArgumentException ex)
        {
            return StatusCode(403, ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpDelete]
    [Route("product/{warehouseId}")]
    public ActionResult<Product> DeleteProduct([FromRoute] int warehouseId, [FromBody] DeleteProductFromWarehouseModel model)
    {
       
        try
        {
            return Ok(_warehouseService.DeleteProduct(warehouseId, model));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPost]
    [Route("productAdd/{userId}")]
    public ActionResult<Product> AddProduct([FromRoute] int userId, [FromBody] PostProductInWarehouseDTO pinDTO)
    {
        try
        {
            var result = _warehouseService.AddProduct(pinDTO, userId);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.ToString());
        }
        catch (ArgumentException ex)
        {
            return StatusCode(403, ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpGet]
    [Route("user/{id}")]
    public ActionResult<List<User>> GetUsers([FromRoute] int id) 
    {
        try
        {
            return Ok(_warehouseService.GetUsers(id));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPost]
    [Route("userAdd/{requestedUserId}")]
    public ActionResult<User> AddUser([FromRoute] int requestedUserId,[FromBody] PostUserInWarehouseDTO uiwDTO)
    {
        try
        {
            var result = _warehouseService.AddUser(uiwDTO, requestedUserId);
            return Ok(result);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.ToString());
        }
        catch (ArgumentException ex)
        {
            return StatusCode(403, ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpDelete]
    [Route("user/{warehouseId}")]
    public ActionResult<Product> RemoveUser([FromRoute] int warehouseId, [FromBody] int userId)
    {
        try
        {
            return Ok(_warehouseService.RemoveUser(warehouseId, userId));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPut]
    [Route("user/{userId}")]
    public ActionResult<Product> UpdateUserAccessLevel([FromRoute] int userId,[FromBody] PutUserInWarehouseDTO uiwDTO)
    {
        try
        {
            var resutl = _warehouseService.UpdateUserAccessLevel(uiwDTO, userId);
            return Ok(resutl);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.ToString());
        }
        catch (ArgumentException ex)
        {
            return StatusCode(403, ex.ToString());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }
}