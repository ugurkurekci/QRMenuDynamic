namespace Application.DTOs.OrderDetail;

public class CreateOrderDetailDto
{

    public int OrderId { get; set; }

    public int MenuItemId { get; set; }

    public int Quantity { get; set; }

    public string SpecialNotes { get; set; }

    public decimal SubTotal { get; set; }

}