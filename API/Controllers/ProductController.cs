using Application.DTOs;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/Product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Route("")]
    public ActionResult<List<Product>> GetAllProducts()
    {
       try
        {
            return Ok(_productService.GetAllProducts());
        }
        catch (Exception ex) 
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpGet]
    [Route("/{id}")] //localhost:5001/product/42
    public ActionResult<Product> GetProductById(int id)
    {
        try
        {
            return Ok(_productService.GetProductById(id));
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
    public ActionResult<Product> CreateNewProduct(PostProductDTO dto)
    {
        try
        {
            var product = _productService.CreateNewProduct(dto);
            return Ok(Created($"product/{product.Id}", product));
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
    [Route("/{id}")] //localhost:5001/product/8732648732
    public ActionResult<Product> UpdateProduct([FromRoute] int id, [FromBody] PutProductDTO product)
    {
        try
        {
            var result = _productService.UpdateProduct(id, product);
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
    [Route("/{id}")]
    public ActionResult<Product> DeleteProduct(int id)
    {
        try
        {
            return Ok(_productService.DeleteProduct(id));
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