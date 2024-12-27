using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    public DbSet<Business> Business { get; set; }

    public DbSet<MenuItem> MenuItem { get; set; }

    public DbSet<Order> Order { get; set; }

    public DbSet<OrderDetail> OrderDetail { get; set; }

    public DbSet<OrderHandler> OrderHandler { get; set; }

    public DbSet<OrderStatus> OrderStatus { get; set; }

    public DbSet<Table> Table { get; set; }

    public DbSet<User> User { get; set; }

    public DbSet<Role> Role { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=RestaurantManagement;User Id=sa;Password=Password123;");
    }

}