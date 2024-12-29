namespace Application.DTOs.Auth;

public class RegisterDto
{

    public int RoleId { get; set; }

    public int BusinessId { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

}