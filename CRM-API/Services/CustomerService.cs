using CRM_API.DTOs;
using CRM_API.Entities;
using CRM_API.Mappers;
using CRM_API.Repository;
using CRM_API.Validations;
using FluentValidation;

namespace CRM_API.Services;

public class CustomerService
{
    private readonly CustomerRepository _customersRepo;
    private readonly AddCustomerValidator _addCustomerValidator;
    private readonly GetCustomersByNameValidator _getCustomersByNameValidator;

    public CustomerService()
    {
        _customersRepo = new CustomerRepository();
        _addCustomerValidator = new AddCustomerValidator();
        _getCustomersByNameValidator = new GetCustomersByNameValidator();
    }

    public DCustomer AddCustomer(DCustomer newCustomer)
    {
        _addCustomerValidator.ValidateAndThrow(newCustomer);
        var CustomerToEntity = Mapper.Instance.Map<DCustomer, ECustomer>(newCustomer);
        var addCustomer = _customersRepo.AddCustomer(CustomerToEntity);
        return Mapper.Instance.Map<ECustomer, DCustomer>(addCustomer);
    }

    public List<DCustomer> GetCustomerByName(string name)
    {
        _getCustomersByNameValidator.ValidateAndThrow(name);
        return Mapper.Instance.Map<List<ECustomer>,List<DCustomer>>(_customersRepo.GetCustomersByName(name));
    }
}