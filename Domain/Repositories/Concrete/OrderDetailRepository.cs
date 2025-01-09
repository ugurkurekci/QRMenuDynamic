using Domain.Data;
using Domain.Entities;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Concrete;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly AppDbContext _context;

    public OrderDetailRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(OrderDetail orderDetail)
    {
        var entity = _context.OrderDetail.Add(orderDetail);
        await _context.SaveChangesAsync();
        return entity.Entity.Id;
    }
}