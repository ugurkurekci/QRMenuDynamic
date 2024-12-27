using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Role
{

    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<User> User { get; set; }

}