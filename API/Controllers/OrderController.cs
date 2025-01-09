using Application.Commands.OrderCommand;
using Application.DTOs.Order;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class OrderController : BaseController
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOrderDto orderDto)
    {
        return Ok(await _mediator.Send(new CreateOrderCommand(orderDto)));
    }
}