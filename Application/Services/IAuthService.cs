using Application.DTOs.Auth;

namespace Application.Services;

public interface IAuthService
{

    Task<int> Register(RegisterDto dto);

    Task<AuthResponse> Login(string email, string password);

}