namespace Application.DTOs.Business;

public class BusinessDto
{

    public int Id { get; set; }

    public string Name { get; set; }

    public string ContactNumber { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

}