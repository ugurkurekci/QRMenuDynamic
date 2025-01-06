using Application.DTOs.OrderStatus;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.OrderStatusQuery;

public class GetAllOrderStatusQuery : IRequest<IReadOnlyList<OrderStatusDto>>
{ }

public class GetAllOrderStatusQueryHandler : IRequestHandler<GetAllOrderStatusQuery, IReadOnlyList<OrderStatusDto>>
{
    private readonly IOrderStatusRepository _orderStatusRepository;
    private readonly IMapper _mapper;

    public GetAllOrderStatusQueryHandler(IOrderStatusRepository orderStatusRepository, IMapper mapper)
    {
        _orderStatusRepository = orderStatusRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<OrderStatusDto>> Handle(GetAllOrderStatusQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<OrderStatus> orderStatus = await _orderStatusRepository.GetAll();
        return _mapper.Map<IReadOnlyList<OrderStatusDto>>(orderStatus);
    }
}