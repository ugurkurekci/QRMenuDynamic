using Application.Commands;
using Application.DTOs.Role;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RoleController : BaseController
{

    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<int>> CreateRole([FromBody] CreateRoleDto roleDto)
    {
        return Ok(await _mediator.Send(new CreateRoleCommand(roleDto)));
    }

}