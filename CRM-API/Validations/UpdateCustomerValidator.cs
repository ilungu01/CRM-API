using CRM_API.DTOs;
using CRM_API.Repository;
using FluentValidation;

namespace CRM_API.Validations;

public class UpdateCustomerValidator : AbstractValidator<DCustomer>
{
    private readonly ICustomerRepository _customerRepository;

    public UpdateCustomerValidator(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
        RuleFor(customer => customer.Id).Must(id => _customerRepository.GetById(id) != null);
        RuleFor(customer => customer.FirstName).NotNull().NotEmpty().Matches("^[a-zA-Z+$]");
        RuleFor(customer => customer.LastName).NotNull().NotEmpty().Matches("^[a-zA-Z+$]");
        RuleFor(customer => customer.Address).NotNull().NotEmpty();
        
    }
}