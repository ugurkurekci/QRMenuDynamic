using Application.DTOs.Role;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class RoleProfile : Profile
{

    public RoleProfile()
    {
        CreateMap<CreateRoleDto, Role>()
            .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => DateTime.Now))
            .ForMember(x => x.IsDeleted, opt => opt.MapFrom(x => false));
    }

}