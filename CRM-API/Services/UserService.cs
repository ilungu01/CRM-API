using CRM_API.DTOs;
using CRM_API.Entities;
using CRM_API.Mappers;
using CRM_API.Repository;
using CRM_API.Validations;
using FluentValidation;

namespace CRM_API.Services;

public class UserService
{
    private readonly UserRepository _usersRepo;
    private readonly AddUserValidator _addUserValidator;

    public UserService()
    {
        _usersRepo = new UserRepository();
        _addUserValidator = new AddUserValidator();
    }

    public DUser AddUser(DUser newUser)
    {
        _addUserValidator.ValidateAndThrow(newUser);
        var userToEntity = Mapper.Instance.Map<DUser, EUser>(newUser);
        var addUser = _usersRepo.AddUser(userToEntity);
        return Mapper.Instance.Map<EUser, DUser>(addUser);
    }
}