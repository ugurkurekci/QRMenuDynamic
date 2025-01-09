using Application.DTOs.Order;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Commands.OrderCommand;

public class CreateOrderCommand : IRequest<int>
{
    public CreateOrderDto CreateOrderDto { get; set; }

    public CreateOrderCommand(CreateOrderDto createOrderDto)
    {
        CreateOrderDto = createOrderDto;
    }
}

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order = _mapper.Map<Order>(request.CreateOrderDto);
        return await _orderRepository.Add(order);
    }
}