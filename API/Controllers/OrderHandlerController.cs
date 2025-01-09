using Application.Commands.OrderHandlerCommand;
using Application.DTOs.OrderHandler;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class OrderHandlerController : BaseController
{

    private readonly IMediator _mediator;

    public OrderHandlerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<int>> CreateBusiness([FromBody] CreateOrderHandlerDto orderHandlerDto)
    {
        return Ok(await _mediator.Send(new CreateOrderHandlerCommand(orderHandlerDto)));
    }
}
