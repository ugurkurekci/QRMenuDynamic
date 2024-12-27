namespace Domain.Entities;

public class OrderStatus
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Order> Order { get; set; }

    public ICollection<OrderHandler> OrderHandler { get; set; }

}