using CRM_API.DTOs;
using CRM_API.Repository;
using FluentValidation;

namespace CRM_API.Validations;

public class DeleteCustomerValidator : AbstractValidator<DCustomer>
{
    private readonly CustomerRepository _customerRepository;

    public DeleteCustomerValidator()
    {
        _customerRepository = new CustomerRepository();
        RuleFor(user => user.Id).Must(id => _customerRepository.GetCustomerById(id) != null).NotNull();
    }
}