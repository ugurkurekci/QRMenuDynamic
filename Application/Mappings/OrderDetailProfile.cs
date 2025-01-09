using Application.DTOs.OrderDetail;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class OrderDetailProfile : Profile
{
    public OrderDetailProfile()
    {
        CreateMap<CreateOrderDetailDto, OrderDetail>();
    }
}