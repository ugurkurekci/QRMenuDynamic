using Domain.Data;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Concrete;

public class OrderStatusRepository : IOrderStatusRepository
{
    private readonly AppDbContext _context;

    public OrderStatusRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrderStatus>> GetAll()
    {
        var orderStatuses = await _context.OrderStatus.ToListAsync();
        if (orderStatuses == null)
        {
            return new List<OrderStatus>();
        }
        return orderStatuses;
    }
}