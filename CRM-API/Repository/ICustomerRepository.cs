using CRM_API.Entities;

namespace CRM_API.Repository;

public interface ICustomerRepository : IRepository<ECustomer>
{
    List<ECustomer> GetByName(string name);
}