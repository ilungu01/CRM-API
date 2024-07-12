using CRM_API.DTOs;
using CRM_API.Entities;
using CRM_API.Mappers;
using CRM_API.Repository;
using CRM_API.Validations;
using FluentValidation;

namespace CRM_API.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepo;
    private readonly AddCustomerValidator _addCustomerValidator;
    private readonly IValidator<string> _getCustomersByNameValidator;
    private readonly IValidator<DCustomer> _deleteCustomerValidator;
    private readonly IValidator<DCustomer> _updateCustomerValidator;

    public CustomerService(
        ICustomerRepository customerRepo,
        IValidator<DCustomer> addCustomerValidator,
        IValidator<string> getCustomersByNameValidator,
        IValidator<DCustomer> deleteCustomerValidator,
        IValidator<DCustomer> updateCustomerValidator)
    {
        _customerRepo = customerRepo;
        _addCustomerValidator = new AddCustomerValidator();
        _getCustomersByNameValidator = getCustomersByNameValidator;
        _updateCustomerValidator = updateCustomerValidator;
        _deleteCustomerValidator = deleteCustomerValidator;
    }

    public DCustomer AddCustomer(DCustomer newCustomer)
    {
        _addCustomerValidator.ValidateAndThrow(newCustomer);
        var customerToEntity = Mapper.Instance.Map<DCustomer, ECustomer>(newCustomer);
        var addedCustomer = _customerRepo.Add(customerToEntity);
        if (addedCustomer.Age > 18)
        {
            SendEmail(addedCustomer);
        }
        return Mapper.Instance.Map<ECustomer, DCustomer>(addedCustomer);
    }

    public List<DCustomer> GetCustomerByName(string name)
    {
        _getCustomersByNameValidator.ValidateAndThrow(name);
        return Mapper.Instance.Map<List<ECustomer>, List<DCustomer>>(_customerRepo.GetByName(name));
    }

    public List<DCustomer> GetAllCustomers()
    {
        return Mapper.Instance.Map<List<ECustomer>, List<DCustomer>>(_customerRepo.GetAll());
    }

    public DCustomer UpdateCustomer(int customerId, DCustomer updatedCustomerData)
    {
        _updateCustomerValidator.ValidateAndThrow(updatedCustomerData);
        var customerToEntity = Mapper.Instance.Map<DCustomer, ECustomer>(updatedCustomerData);
        var updatedCustomer = _customerRepo.Update(customerId, customerToEntity);
        return Mapper.Instance.Map<ECustomer, DCustomer>(updatedCustomer);
    }

    public DCustomer GetCustomerById(int customerId)
    {
        return Mapper.Instance.Map<ECustomer, DCustomer>(_customerRepo.GetById(customerId));
    }

    public void DeleteCustomer(DCustomer customer)
    {
        _deleteCustomerValidator.ValidateAndThrow(customer);
        _customerRepo.Delete(customer.Id);
    }

    private void SendEmail(ECustomer customer)
    {
        Console.WriteLine($"Sending email to {customer.Email}");
    }
}