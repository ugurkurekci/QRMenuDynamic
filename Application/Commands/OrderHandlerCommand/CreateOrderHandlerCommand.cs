using Application.DTOs.OrderHandler;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Commands.OrderHandlerCommand;

public class CreateOrderHandlerCommand : IRequest<int>
{
    public CreateOrderHandlerDto OrderHandlerDto { get; set; }

    public CreateOrderHandlerCommand(CreateOrderHandlerDto orderHandlerDto)
    {
        OrderHandlerDto = orderHandlerDto;
    }
}

public class CreateOrderHandlerCommandHandler : IRequestHandler<CreateOrderHandlerCommand, int>
{
    private readonly IOrderHandlerRepository _orderHandlerRepository;
    private readonly IMapper _mapper;

    public CreateOrderHandlerCommandHandler(IOrderHandlerRepository orderHandlerRepository, IMapper mapper)
    {
        _orderHandlerRepository = orderHandlerRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateOrderHandlerCommand request, CancellationToken cancellationToken)
    {
        OrderHandler orderHandler = _mapper.Map<OrderHandler>(request.OrderHandlerDto);
        return await _orderHandlerRepository.Add(orderHandler);
    }
}