using CRM_API.DTOs;
using CRM_API.Repository;
using FluentValidation;

namespace CRM_API.Validations;

public class DeleteCustomerValidator : AbstractValidator<DCustomer>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerValidator(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
        RuleFor(user => user.Id).Must(id => _customerRepository.GetById(id) != null).NotNull();
    }
}