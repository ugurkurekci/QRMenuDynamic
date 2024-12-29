using Application.DTOs.Auth;
using Application.Services;
using MediatR;

namespace Application.Authorization;

public class RegisterCommand : IRequest<int>
{

    public RegisterDto RegisterDto { get; set; }

    public RegisterCommand(RegisterDto registerDto)
    {
        RegisterDto = registerDto;
    }

}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, int>
{
    private readonly IAuthService _authService;
    public RegisterCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }
    public async Task<int> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await _authService.Register(request.RegisterDto);
    }
}