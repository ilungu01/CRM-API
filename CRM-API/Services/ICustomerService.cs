using CRM_API.DTOs;

namespace CRM_API.Services;

public interface ICustomerService
{
    DCustomer AddCustomer(DCustomer newCustomer);
    List<DCustomer> GetCustomerByName(string name);
    DCustomer UpdateCustomer(int customerId, DCustomer updatedCustomerData);
    DCustomer GetCustomerById(int customerId);
    void DeleteCustomer(DCustomer customer);
    List<DCustomer> GetAllCustomers();
}