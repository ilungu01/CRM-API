using CRM_API.DTOs;
using CRM_API.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CRM_API.Controllers;

[ApiController]
[Route("api/Customers/[controller]")]
public class CustomerController : ControllerBase
{

    private readonly ICustomerServiceFactory _customerServiceFactory;

    public CustomerController(ICustomerServiceFactory customerServiceFactory)
    {
        _customerServiceFactory = customerServiceFactory;
    }

    private ICustomerService CustomerService => _customerServiceFactory.CreateCustomerService();
    
    [HttpGet("byName/{name}")]
    public ActionResult<List<DCustomer>> GetCustomerByName([FromRoute] string name)
    {
        try
        {
            return Ok(CustomerService.GetCustomerByName(name));
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
            return Ok(CustomerService.UpdateCustomer(id,updatedCustomerData));
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
            CustomerService.AddCustomer(newCustomer);
            return Ok(newCustomer);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }

    [HttpGet]
    public ActionResult<List<DCustomer>> GetAllCustomers()
    {
        return Ok(CustomerService.GetAllCustomers());
    }

    [HttpGet("{id}")]
    public ActionResult<DCustomer> GetCustomerById([FromRoute] int id)
    {
        return CustomerService.GetCustomerById(id);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCustomer([FromRoute] int id)
    {
        try
        {
            var customer = new DCustomer();
            customer.Id = id;
            CustomerService.DeleteCustomer(customer);
            return Ok("Customer was deleted");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
    }
}