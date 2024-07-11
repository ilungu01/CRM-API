using CRM_API.DTOs;
using CRM_API.Entities;
using CRM_API.Mappers;
using CRM_API.Repository;
using CRM_API.Validations;
using FluentValidation;

namespace CRM_API.Services;

public class CustomerService
{
    private readonly CustomerRepository _customerRepo;
    private readonly AddCustomerValidator _addCustomerValidator;
    private readonly GetCustomersByNameValidator _getCustomersByNameValidator;
    private readonly DeleteCustomerValidator _deleteCustomerValidator;
    private readonly UpdateCustomerValidator _updateCustomerValidator;

    public CustomerService()
    {
        _customerRepo = new CustomerRepository();
        _addCustomerValidator = new AddCustomerValidator();
        _getCustomersByNameValidator = new GetCustomersByNameValidator();
        _updateCustomerValidator = new UpdateCustomerValidator();
        _deleteCustomerValidator = new DeleteCustomerValidator();
    }

    public DCustomer AddCustomer(DCustomer newCustomer)
    {
        _addCustomerValidator.ValidateAndThrow(newCustomer);
        var CustomerToEntity = Mapper.Instance.Map<DCustomer, ECustomer>(newCustomer);
        var addCustomer = _customerRepo.AddCustomer(CustomerToEntity);
        return Mapper.Instance.Map<ECustomer, DCustomer>(addCustomer);
    }

    public List<DCustomer> GetCustomerByName(string name)
    {
        _getCustomersByNameValidator.ValidateAndThrow(name);
        return Mapper.Instance.Map<List<ECustomer>,List<DCustomer>>(_customerRepo.GetCustomersByName(name));
    }

    public DCustomer UpdateCustomer(int customerId, DCustomer updatedCustomerData)
    {
        _updateCustomerValidator.ValidateAndThrow(updatedCustomerData);
        var customerToEntity = Mapper.Instance.Map<DCustomer, ECustomer>(updatedCustomerData);
        var updatedCustomer = _customerRepo.UpdateCustomer(customerId,customerToEntity);
        return Mapper.Instance.Map<ECustomer, DCustomer>(updatedCustomer);
    }

    public DCustomer GetCustomerById(int customerId)
    {
        return Mapper.Instance.Map<ECustomer,DCustomer>(_customerRepo.GetCustomerById(customerId));
    }

    public void DeleteCustomer(DCustomer customer)
    {
        _deleteCustomerValidator.ValidateAndThrow(customer);
        _customerRepo.DeleteCustomer(customer.Id);
    }
}