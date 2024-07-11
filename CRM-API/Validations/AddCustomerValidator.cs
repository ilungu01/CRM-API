using CRM_API.DTOs;
using FluentValidation;

namespace CRM_API.Validations;

public class AddCustomerValidator : AbstractValidator<DCustomer>
{
    public AddCustomerValidator()
    {
        RuleFor(customer => customer.FirstName).NotNull().NotEmpty();
        RuleFor(customer => customer.LastName).NotNull().NotEmpty();
        RuleFor(customer => customer.Address).NotNull().NotEmpty();
        RuleFor(customer => customer.Age).NotNull().NotEmpty();
    }
}