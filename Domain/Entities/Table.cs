using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Table
{

    [Key]
    public int Id { get; set; }

    [ForeignKey("Business")]
    public int BusinessId { get; set; }

    public string QrCode { get; set; }

    public string TableNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public Business Business { get; set; }

    public ICollection<Order> Order { get; set; }

}