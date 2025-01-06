using Application.DTOs.OrderStatus;
using Application.Queries.OrderStatusQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class OrderStatusController : BaseController
{
    private readonly IMediator _mediator;

    public OrderStatusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IReadOnlyList<OrderStatusDto>>> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllOrderStatusQuery()));
    }
}