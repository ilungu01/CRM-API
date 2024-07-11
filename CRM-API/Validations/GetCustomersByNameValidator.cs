using CRM_API.DTOs;
using FluentValidation;

namespace CRM_API.Validations;

public class GetCustomersByNameValidator : AbstractValidator<string>
{
    public GetCustomersByNameValidator()
    {
        RuleFor(name => name).NotEmpty().NotNull().Matches("^[a-zA-Z+$]");
    }
}