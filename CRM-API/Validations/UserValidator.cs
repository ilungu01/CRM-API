using CRM_API.DTOs;
using FluentValidation;

namespace CRM_API.Validations;

public class AddUserValidator : AbstractValidator<DUser>
{
    public AddUserValidator()
    {
        RuleFor(user => user.FirstName).NotNull().NotEmpty();
        RuleFor(user => user.LastName).NotNull().NotEmpty();
        RuleFor(user => user.Address).NotNull().NotEmpty();
        RuleFor(user => user.Age).NotNull().NotEmpty();
    }
}