using Application.DTOs;
using Application.Interfaces;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_warehouseService.GetAllWarehouses());
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
            return Ok(_warehouseService.GetWarehouseById(id));
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
            var warehouse = _warehouseService.CreateNewWarehouse(dto);
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
            var result = _warehouseService.UpdateWarehouse(id, dto);
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
            return Ok(_warehouseService.DeleteWarehouse(id));
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
}