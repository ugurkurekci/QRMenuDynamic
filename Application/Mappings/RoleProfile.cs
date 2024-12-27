using Application.DTOs.Role;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, CreateRoleDto>().ReverseMap();
    }

}