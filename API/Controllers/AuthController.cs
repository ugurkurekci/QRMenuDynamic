using Application.Authorization;
using Application.DTOs.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthController : BaseController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ActionResult<int>> Register([FromBody] RegisterDto registerDto)
    {
        return Ok(await _mediator.Send(new RegisterCommand(registerDto)));
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginDto loginDto)
    {
        return Ok(await _mediator.Send(new LoginCommand(loginDto.Email, loginDto.Password)));
    }
}