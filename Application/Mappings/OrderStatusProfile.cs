using Application.DTOs.OrderStatus;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class OrderStatusProfile : Profile
{
    public OrderStatusProfile()
    {
        CreateMap<OrderStatus, OrderStatusDto>();
    }
}