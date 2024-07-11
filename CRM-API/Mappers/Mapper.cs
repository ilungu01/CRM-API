using AutoMapper;
using CRM_API.DTOs;
using CRM_API.Entities;

namespace CRM_API.Mappers;

public class Mapper
{
    public static IMapper Instance { get; set; } = Configure();

    private static IMapper Configure()
    {
        return new MapperConfiguration(config =>
        {
            config.CreateMap<DCustomer, ECustomer>().ReverseMap();
        }).CreateMapper();
    }
}