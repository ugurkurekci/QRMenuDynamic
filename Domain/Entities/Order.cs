using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Order
{

    [Key]
    public int Id { get; set; }

    [ForeignKey("Table")]
    public int TableId { get; set; }

    public decimal TotalPrice { get; set; }

    [ForeignKey("OrderStatus")]
    public int OrderStatusId { get; set; }

    public DateTime CreatedAt { get; set; }

    public Table Table { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public ICollection<OrderDetail> OrderDetail { get; set; }

    public ICollection<OrderHandler> OrderHandler { get; set; }


}