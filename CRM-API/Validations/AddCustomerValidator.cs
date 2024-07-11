using CRM_API.DTOs;
using FluentValidation;

namespace CRM_API.Validations;

public class AddCustomerValidator : AbstractValidator<DCustomer>
{
    public AddCustomerValidator()
    {
        RuleFor(user => user.FirstName).NotNull().NotEmpty();
        RuleFor(user => user.LastName).NotNull().NotEmpty();
        RuleFor(user => user.Address).NotNull().NotEmpty();
        RuleFor(user => user.Age).NotNull().NotEmpty();
    }
}