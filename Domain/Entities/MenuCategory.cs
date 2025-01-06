using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class MenuCategory
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<MenuItem> MenuItem { get; set; }
}