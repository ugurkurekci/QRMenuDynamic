namespace Application.DTOs.OrderHandler;

public class CreateOrderHandlerDto
{

    public int Id { get; set; }

    public int OrderStatusId { get; set; }

    public int OrderId { get; set; }

    public int UserId { get; set; }

}