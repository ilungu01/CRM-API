using CRM_API.DTOs;
using CRM_API.Repository;
using FluentValidation;

namespace CRM_API.Services;

public class CustomerServiceFactory : ICustomerServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public CustomerServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public ICustomerService CreateCustomerService()
    {
        var customerRepository = _serviceProvider.GetRequiredService<ICustomerRepository>();
        var updateCustomerValidator = _serviceProvider.GetRequiredService<IValidator<DCustomer>>();
        var deleteCustomerValidator = _serviceProvider.GetRequiredService<IValidator<DCustomer>>();
        var getCustomerByName = _serviceProvider.GetRequiredService<IValidator<string>>();

        return new CustomerService(customerRepository, getCustomerByName, deleteCustomerValidator,
            updateCustomerValidator);
    }
}