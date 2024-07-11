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

    [HttpGet("byName/{name}")]
    public ActionResult<List<DCustomer>> GetCustomerByName([FromRoute] string name)
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

    [HttpPut("{id}")]
    public ActionResult<DCustomer> UpdateCustomer([FromRoute] int id, [FromBody] DCustomer updatedCustomerData)
    {
        try
        {
            updatedCustomerData.Id = id;
            return Ok(_customerService.UpdateCustomer(id,updatedCustomerData));
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

    [HttpGet("{id}")]
    public ActionResult<DCustomer> GetCustomerById([FromRoute] int id)
    {
        return _customerService.GetCustomerById(id);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCustomer([FromRoute] int id)
    {
        try
        {
            var customer = new DCustomer();
            customer.Id = id;
            _customerService.DeleteCustomer(customer);
            return Ok("Customer was deleted");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }
}