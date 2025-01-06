namespace Application.DTOs.Table;

public class TableDto
{
    public int Id { get; set; }

    public int BusinessId { get; set; }

    public string QrCode { get; set; }

    public string TableNumber { get; set; }

    public DateTime CreatedAt { get; set; }
}