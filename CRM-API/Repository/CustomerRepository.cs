using CRM_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM_API.Repository;

public class CustomerRepository : ICustomerRepository
{
    public ECustomer Add(ECustomer newCustomer)
    {
        using var context = new CRMDBContext();
        context.Add(newCustomer);
        context.SaveChanges();
        return GetById(newCustomer.Id);
    }

    public ECustomer? GetById(int id)
    {
        using var context = new CRMDBContext();
        return context.Customers.FirstOrDefault(customer => customer.Id == id);
    }

    public List<ECustomer> GetAll()
    {
        using var context = new CRMDBContext();
        return context.Customers.ToList();
    }

    public List<ECustomer> GetByName(string name)
    {
        using var context = new CRMDBContext();
        var output = context.Customers.Where(u => u.FirstName.Contains(name)).ToList();
        return output;
    }

    public void Delete(int customerId)
    {
        using var context = new CRMDBContext();
        var customer = context.Customers.FirstOrDefault(customer => customer.Id == customerId);
        context.Customers.Remove(customer);
        context.SaveChanges();
    }

    public ECustomer Update(int customerId, ECustomer updatedCustomerData)
    {
        using var context = new CRMDBContext();
        var customerToUpdate = GetById(customerId);
        context.Entry(customerToUpdate).CurrentValues.SetValues(updatedCustomerData);
        context.Entry(customerToUpdate).State = EntityState.Modified;
        context.SaveChanges();
        return GetById(customerId);
    }
}