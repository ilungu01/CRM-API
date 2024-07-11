using CRM_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM_API.Repository;

public class CustomerRepository
{
    public ECustomer AddCustomer(ECustomer newCustomer)
    {
        using var context = new CRMDBContext();
        context.Add(newCustomer);
        context.SaveChanges();
        return GetCustomerById(newCustomer.Id);
    }

    public ECustomer? GetCustomerById(int id)
    {
        using var context = new CRMDBContext();
        return context.Customers.FirstOrDefault(customer => customer.Id == id);
    }

    public List<ECustomer> GetCustomersByName(string name)
    {
        using var context = new CRMDBContext();
        var output = context.Customers.Where(u => u.FirstName.Contains(name)).ToList();
        return output;
    }

    public void DeleteCustomer(int customerId)
    {
        using var context = new CRMDBContext();
        var customer = context.Customers.FirstOrDefault(customer => customer.Id == customerId);
        context.Customers.Remove(customer);
        context.SaveChanges();
    }

    public ECustomer UpdateCustomer(int customerId, ECustomer updatedCustomerData)
    {
        using var context = new CRMDBContext();
        var customerToUpdate = GetCustomerById(customerId);
        context.Entry(customerToUpdate).CurrentValues.SetValues(updatedCustomerData);
        context.Entry(customerToUpdate).State = EntityState.Modified;
        context.SaveChanges();
        return GetCustomerById(customerId);
    }
}