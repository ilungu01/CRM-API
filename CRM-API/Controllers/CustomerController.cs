using CRM_API.DTOs;
using CRM_API.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers;

[ApiController]
[Route("api/Customers/[controller]")]
public class CustomerController : ControllerBase
{

    private readonly CustomerService _customerService;

    public CustomerController()
    {
        _customerService = new CustomerService();
    }

    [HttpGet("{name}")]
    public ActionResult<List<DCustomer>> GetCustomerByName(string name)
    {
        try
        {
            return Ok(_customerService.GetCustomerByName(name));
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    [HttpPost]
    public ActionResult<DCustomer> AddCustomer([FromBody] DCustomer newCustomer)
    {
        try
        {
            _customerService.AddCustomer(newCustomer);
            return Ok(newCustomer);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCustomer([FromRoute] int id)
    {
        try
        {
            return Ok("Customer was deleted");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }
}