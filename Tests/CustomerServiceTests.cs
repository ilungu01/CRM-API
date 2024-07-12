using CRM_API.DTOs;
using CRM_API.Entities;
using CRM_API.Repository;
using CRM_API.Services;
using CRM_API.Validations;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace Tests;

public class CustomerServiceTests
{
    private readonly Mock<ICustomerRepository> _customerRepositoryMock;
    private readonly AddCustomerValidator _addValidatorMock;
    private readonly Mock<IValidator<DCustomer>> _updateValidatorMock;
    private readonly Mock<IValidator<DCustomer>> _deleteValidatorMock;
    private readonly Mock<IValidator<string>> _getCustomersByNameValidator;
    private readonly ICustomerService _customerService;

    public CustomerServiceTests()
    {
        _customerRepositoryMock = new Mock<ICustomerRepository>();
        _updateValidatorMock = new Mock<IValidator<DCustomer>>();
        _deleteValidatorMock = new Mock<IValidator<DCustomer>>();
        _getCustomersByNameValidator = new Mock<IValidator<string>>();
        _customerService = new CustomerService(
            _customerRepositoryMock.Object,
            _getCustomersByNameValidator.Object,
            _deleteValidatorMock.Object,
            _updateValidatorMock.Object
        );
    }
    
    [Fact]
    public void AddCustomer_WithValidCustomer_ShouldCallAdd()
    {
        var customer = new DCustomer { Id = 1, FirstName = "John", LastName = "Doe", Address = "123 Main St", Age = 30 };
        var addedCustomer = new ECustomer { Id = 1, FirstName = "John", LastName = "Doe", Address = "123 Main St", Age = 30 };
        _customerRepositoryMock.Setup(repo => repo.Add(It.IsAny<ECustomer>()))
            .Returns(addedCustomer);
        
        var result = _customerService.AddCustomer(customer);
        
        _customerRepositoryMock.Verify(repo => repo.Add(It.IsAny<ECustomer>()), Times.Once);
        Assert.Equal("John", result.FirstName);
        Assert.Equal("Doe", result.LastName);
        Assert.Equal("123 Main St", result.Address);
        Assert.Equal(30, result.Age);
    }
    
    [Fact]
    public void AddCustomer_WithInvalidCustomer_ShouldThrowValidationException()
    {
        var customer = new DCustomer { Id = 1, FirstName = "", LastName = "", Address = "", Age = 0 };
        
        var exception = Assert.Throws<ValidationException>(() => _customerService.AddCustomer(customer));
        Assert.Contains(exception.Errors, error => error.PropertyName == "FirstName" && error.ErrorMessage == "'First Name' must not be empty.");
        Assert.Contains(exception.Errors, error => error.PropertyName == "LastName" && error.ErrorMessage == "'Last Name' must not be empty.");
        Assert.Contains(exception.Errors, error => error.PropertyName == "Address" && error.ErrorMessage == "'Address' must not be empty.");
        Assert.Contains(exception.Errors, error => error.PropertyName == "Age" && error.ErrorMessage == "'Age' must not be empty.");
    }

}