using Application.Commands;
using Application.DTOs.Business;
using Application.Middleware;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BusinessController : BaseController
{
    private readonly IMediator _mediator;

    public BusinessController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<int>> CreateBusiness([FromBody] CreateBusinessDto businessDto)
    {
        return Ok(await _mediator.Send(new CreateBusinessCommand(businessDto)));
    }

    [HttpGet]
    [AccessRole(["Admin", "Manager"])]
    public async Task<ActionResult<IReadOnlyList<BusinessDto>>> GetBusinesses()
    {
        return Ok(await _mediator.Send(new GetAllBusinessQuery()));
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<BusinessDto>> GetBusiness(int id)
    {
        return Ok(await _mediator.Send(new GetByIdBusinessQuery(id)));
    }
}