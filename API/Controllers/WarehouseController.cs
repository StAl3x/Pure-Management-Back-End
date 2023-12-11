using Application.DTOs;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
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
    [Route("")]
    public ActionResult<List<Warehouse>> GetAllWarehouses()
    {
        try
        {
            return Ok(_warehouseService.GetAll());
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
    public ActionResult<Warehouse> CreateNewWarehouse(PostWarehouseDTO dto)
    {
        try
        {
            var warehouse = _warehouseService.Create(dto);
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
    public ActionResult<Warehouse> UpdateWarehouse([FromRoute] int id, [FromBody] PutWarehouseDTO dto)
    {
        try
        {
            var result = _warehouseService.Update(id, dto);
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
    public ActionResult<Warehouse> DeleteWarehouse(int id)
    {
        try
        {
            return Ok(_warehouseService.Delete(id));
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
    [Route("product/")]
    public ActionResult<Product> CreateProduct([FromBody] PostProductModel model) 
    {
        var pinDTO = model.PinDTO;
        var productDTO = model.ProductDTO;

        try
        {
            var result = _warehouseService.CreateProduct(pinDTO, productDTO);
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
    [Route("product/")]
    public ActionResult<Product> UpdateProduct([FromBody] PutProductModel model) 
    {
        var pinDTO = model.PinDTO;
        var productDTO = model.ProductDTO;
        try
        {
            var resutl = _warehouseService.UpdateProduct(pinDTO, productDTO);
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

    [HttpDelete]
    [Route("product/{id}")]
    public ActionResult<Product> DeleteProduct([FromRoute] int id, [FromBody] bool deleteFromProductTable)
    {
        try
        {
            return Ok(_warehouseService.DeleteProduct(id, deleteFromProductTable));
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
    [Route("productAdd/")]
    public ActionResult<Product> AddProduct([FromBody] PostProductInWarehouseDTO pinDTO)
    {
        try
        {
            var result = _warehouseService.AddProduct(pinDTO);
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
    [Route("userAdd/")]
    public ActionResult<User> AddUser([FromBody] PostUserInWarehouseDTO uiwDTO)
    {
        try
        {
            var result = _warehouseService.AddUser(uiwDTO);
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
    [Route("user/{id}")]
    public ActionResult<Product> RemoveUser([FromRoute] int id)
    {
        try
        {
            return Ok(_warehouseService.RemoveUser(id));
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
    [Route("user/")]
    public ActionResult<Product> UpdateUserAccessLevel([FromBody] PutUserInWarehouseDTO uiwDTO)
    {
        try
        {
            var resutl = _warehouseService.UpdateUserAccessLevel(uiwDTO);
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