using CRM_API.Entities;

namespace CRM_API.Repository;

public class UserRepository
{
    public EUser AddUser(EUser newUser)
    {
        using var context = new CRMDBContext();
        context.Add(newUser);
        context.SaveChanges();
        return GetUserById(newUser.Id);
    }

    public EUser? GetUserById(int id)
    {
        using var context = new CRMDBContext();
        return context.Users.FirstOrDefault(user => user.Id == id);
    }
}