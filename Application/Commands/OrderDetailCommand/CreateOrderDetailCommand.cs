using Application.DTOs.OrderDetail;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Commands.OrderDetailCommand;

public class CreateOrderDetailCommand : IRequest<int>
{
    public CreateOrderDetailDto OrderDetailDto { get; set; }

    public CreateOrderDetailCommand(CreateOrderDetailDto orderDetailDto)
    {
        OrderDetailDto = orderDetailDto;
    }
}

public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, int>
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly IMapper _mapper;

    public CreateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail orderDetail = _mapper.Map<OrderDetail>(request.OrderDetailDto);
        return await _orderDetailRepository.Add(orderDetail);
    }
}