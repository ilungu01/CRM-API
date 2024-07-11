using CRM_API.DTOs;
using CRM_API.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers;

[ApiController]
[Route("api/users/[controller]")]
public class UserController : ControllerBase
{

    private readonly UserService _userService;

    public UserController()
    {
        _userService = new UserService();
    }
    
    [HttpPost]
    public ActionResult<DUser> AddUser([FromBody] DUser newUser)
    {
        try
        {
            _userService.AddUser(newUser);
            return Ok(newUser);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }
}