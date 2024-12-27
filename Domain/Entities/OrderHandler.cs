using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class OrderHandler
{

    [Key]
    public int Id { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("OrderStatus")]
    public int OrderStatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public Order Order { get; set; }

    public User User { get; set; }

    public OrderStatus OrderStatus { get; set; }

}