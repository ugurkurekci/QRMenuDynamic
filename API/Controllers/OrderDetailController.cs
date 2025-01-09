using Application.Commands.OrderDetailCommand;
using Application.DTOs.OrderDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class OrderDetailController : BaseController
{
    private readonly IMediator _mediator;

    public OrderDetailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<int>> CreateOrderDetail([FromBody] CreateOrderDetailDto orderDetailDto)
    {
        return Ok(await _mediator.Send(new CreateOrderDetailCommand(orderDetailDto)));
    }
}