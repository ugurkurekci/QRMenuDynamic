using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class OrderDetail
{

    [Key]
    public int Id { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }

    [ForeignKey("MenuItem")]
    public int MenuItemId { get; set; }

    public int Quantity { get; set; }

    public string SpecialNotes { get; set; }

    public decimal SubTotal { get; set; }

    public MenuItem MenuItem { get; set; }

    public Order Order { get; set; }

}