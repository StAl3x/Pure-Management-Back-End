using Application.Interfaces;
using Domain;
using Domain.DTOs;
using Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;


[ApiController]
[Route("api/Company")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    [Route("")]
    public ActionResult<List<Company>> GetAll()
    {
        try
        {
            return Ok(_companyService.GetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<List<Company>> GetById([FromRoute] int id)
    {
        try
        {
            return Ok(_companyService.GetById(id));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPost]
    [Route("/CompanyUsers{id}")]
    public ActionResult<List<User>> GetUsers([FromRoute] int id, [FromBody] int userId)
    {
        try
        {
            return Ok(_companyService.GetUsers(id, userId));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPost]
    [Route("/CompanyProducts{id}")]
    public ActionResult<List<Product>> GetProducts([FromRoute] int id, [FromBody] int userId)
    {
        try
        {
            return Ok(_companyService.GetProducts(id, userId));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPost]
    [Route("/CompanyWarehouses{id}")]
    public ActionResult<List<Warehouse>> GetWarehouses([FromRoute] int id, [FromBody] int userId)
    {
        try
        {
            return Ok(_companyService.GetWarehouses(id, userId));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPost]
    [Route("")]
    public ActionResult<Company> Create(PostCompanyDTO dto)
    {
        try
        {
            var company = _companyService.Create(dto);
            return Ok(Created($"company/{company.Id}", company));
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
    public ActionResult<Company> Update([FromRoute] int id, [FromBody] CompanyModel model)
    {
        try
        {
            var result = _companyService.Update(id, model);
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
    public ActionResult<Company> Delete([FromRoute]int id, [FromBody] int userId)
    {
        try
        {
            return Ok(_companyService.Delete(id, userId));
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
