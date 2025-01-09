using Domain.Data;
using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Concrete;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Order order)
    {
        var entity = _context.Order.Add(order);
        await _context.SaveChangesAsync();
        return entity.Entity.Id;
    }
}