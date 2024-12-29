using Application.DTOs.Business;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class BusinessProfile : Profile
{

    public BusinessProfile()
    {
        CreateMap<CreateBusinessDto, Business>()
            .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => DateTime.Now))
            .ForMember(x => x.IsActive, opt => opt.MapFrom(x => true));

        CreateMap<Business, BusinessDto>();
    }
}