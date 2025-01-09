using Application.DTOs.OrderHandler;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class OrderHandlerProfile : Profile
{
    public OrderHandlerProfile()
    {
        CreateMap<CreateOrderHandlerDto, OrderHandler>()
                   .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => DateTime.Now));
    }
}