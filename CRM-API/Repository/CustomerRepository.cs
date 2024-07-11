using CRM_API.Entities;

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
}