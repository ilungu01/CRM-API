using CRM_API.DTOs;
using CRM_API.Entities;
using CRM_API.Mappers;
using CRM_API.Repository;

namespace CRM_API.Services;

public class UserService
{
    private readonly UserRepository _usersRepo;

    public UserService()
    {
        _usersRepo = new UserRepository();
    }

    public DUser AddUser(DUser newUser)
    {
        var userToEntity = Mapper.Instance.Map<DUser, EUser>(newUser);
        var addUser = _usersRepo.AddUser(userToEntity);
        return Mapper.Instance.Map<EUser, DUser>(addUser);
    }
}