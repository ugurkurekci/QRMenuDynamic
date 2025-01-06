namespace Application.DTOs.Table;

public class CreateTableDto
{
    public int BusinessId { get; set; }

    public string QrCode { get; set; }

    public string TableNumber { get; set; }
}