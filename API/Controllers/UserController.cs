using Domain.DTOs;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace API.Controllers;

[ApiController]
[Route("api/User")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{userId}")]
    public ActionResult<List<User>> GetAll([FromRoute] int userId)
    {
        try
        {
            return Ok(_userService.GetAll(userId));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<User> GetById([FromRoute] int id)
    {
        try
        {
            return Ok(_userService.GetById(id));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }

    [HttpPost]
    [Route("")]
    public ActionResult<User> Create(UserModel model)
    {
        try
        {
            var user = _userService.Create(model);
            return Ok(Created($"user/{user.Id}", user));
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
    [Route("{id}")]
    public ActionResult<User> Update([FromRoute] int id, [FromBody] UserModel model)
    {
        try
        {
            var result = _userService.Update(id, model);
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
    public ActionResult<User> Delete([FromRoute] int id, [FromBody] int userId)
    {
        try
        {
            return Ok(_userService.Delete(id, userId));
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
    [Route("{userName}")]
    public ActionResult<bool> VerifyPassword([FromRoute] string userName, [FromBody] string password)
    {
        try
        {
            return Ok(_userService.VerifyUserPassword(userName, password));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.ToString());
        }
    }
}
