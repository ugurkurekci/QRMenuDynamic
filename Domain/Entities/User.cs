using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class User
{

    [Key]
    public int Id { get; set; }

    [ForeignKey("Business")]
    public int BusinessId { get; set; }

    [ForeignKey("Role")]
    public int RoleId { get; set; }

    public string EMail { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime LastLoginDate { get; set; }

    public bool IsDeleted { get; set; }

    public Business Business { get; set; }

    public Role Role { get; set; }

    public ICollection<OrderHandler> OrderHandler { get; set; }

}