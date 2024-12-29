namespace Application.DTOs.Auth;

public class AuthResponse
{

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public int Role { get; set; }

    public string Token { get; set; }

    public string Email { get; set; }

}