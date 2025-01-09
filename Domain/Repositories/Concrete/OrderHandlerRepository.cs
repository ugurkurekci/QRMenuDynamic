using Domain.Data;
using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Concrete;

public class OrderHandlerRepository : IOrderHandlerRepository
{
    private readonly AppDbContext _context;

    public OrderHandlerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(OrderHandler orderHandler)
    {
        var entity = _context.OrderHandler.Add(orderHandler);
        await _context.SaveChangesAsync();
        return entity.Entity.Id;
    }
}