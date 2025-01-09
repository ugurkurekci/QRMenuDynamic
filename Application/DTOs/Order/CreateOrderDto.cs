namespace Application.DTOs.Order;

public class CreateOrderDto
{
    public int TableId { get; set; }

    public decimal TotalPrice { get; set; }

    public int OrderStatusId { get; set; }

    public DateTime CreatedAt { get; set; }
}