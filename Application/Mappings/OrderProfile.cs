using Application.DTOs.Order;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<CreateOrderDto, Order>();
    }
}