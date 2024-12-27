using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class MenuItem
{

    [Key]
    public int Id { get; set; }

    [ForeignKey("Business")]
    public int BusinessId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public Business Business { get; set; }

    public ICollection<OrderDetail> OrderDetail { get; set; }

}