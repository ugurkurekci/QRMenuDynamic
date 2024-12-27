using Application.Commands;
using Application.DTOs.Role;
using MediatR;
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
    public async Task<ActionResult<int>> CreateRole(CreateRoleDto roleDto)
    {
        var command = new CreateRoleCommand { RoleDto = roleDto };
        return await _mediator.Send(command);
    }

}