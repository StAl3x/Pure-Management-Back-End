using Application.DTOs;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Route("products")]
    public JsonResult GetAllProducts()
    {
        return new JsonResult(_productService.GetAllProducts());
    }

    [HttpPost]
    [Route("")]
    public JsonResult CreateNewProduct(PostProductDTO dto)
    {
        try
        {
            var result = _productService.CreateNewProduct(dto);
            return new JsonResult(Created("", result));
        }
        catch (ValidationException v)
        {
            return new JsonResult(BadRequest(v.Message));
        }
        catch (Exception e)
        {
            return new JsonResult(StatusCode(500, e.Message));
        }
    }

    [HttpGet]
    [Route("{id}")] //localhost:5001/product/42
    public JsonResult GetProductById(int id)
    {
        try
        {
            return new JsonResult(_productService.GetProductById(id));
        }
        catch (KeyNotFoundException e)
        {
            return new JsonResult(NotFound("No product found at ID " + id));
        }
        catch (Exception e)
        {
            return new JsonResult(StatusCode(500, e.ToString()));
        }
    }


    [HttpGet]
    [Route("RebuildDB")]
    public void RebuildDB()
    {
        _productService.RebuildDB();
    }

    [HttpPut]
    [Route("{id}")] //localhost:5001/product/8732648732
    public JsonResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
    {
        try
        {
            return new JsonResult(Ok(_productService.UpdateProduct(id, product)));
        }
        catch (KeyNotFoundException e)
        {
            return new JsonResult(NotFound("No product found at ID " + id));
        }
        catch (Exception e)
        {
            return new JsonResult(StatusCode(500, e.ToString()));
        }
    }


    [HttpDelete]
    [Route("{id}")]
    public JsonResult DeleteProduct(int id)
    {
        try
        {
            return new JsonResult(Ok(_productService.DeleteProduct(id)));
        }
        catch (KeyNotFoundException e)
        {
            return new JsonResult(NotFound("No product found at ID " + id));
        }
        catch (Exception e)
        {
            return new JsonResult(StatusCode(500, e.ToString()));
        }
    }
}