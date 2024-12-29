using Application.DTOs.Auth;
using Application.Services;
using MediatR;

namespace Application.Authorization;

public class LoginCommand : IRequest<AuthResponse>
{
    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
{

    private readonly IAuthService _authService;
    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }
    public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authService.Login(request.Email, request.Password);
    }
}