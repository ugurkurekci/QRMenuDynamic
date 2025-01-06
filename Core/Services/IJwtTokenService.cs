namespace Core.Services;

public interface IJwtTokenService
{
    string GenerateToken(int userId, string userEmail, int roleId);
}