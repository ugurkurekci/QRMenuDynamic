using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Business
{

    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string ContactNumber { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<User> User { get; set; }

    public ICollection<MenuItem> MenuItem { get; set; }

    public ICollection<Table> Table { get; set; }

}