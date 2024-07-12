namespace CRM_API.Services;

public interface ICustomerServiceFactory
{
    ICustomerService CreateCustomerService();
}