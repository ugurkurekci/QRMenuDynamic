using Application.DTOs.Auth;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class AuthProfile : Profile
{

    public AuthProfile()
    {

        CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.LastLoginDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
    }
}
