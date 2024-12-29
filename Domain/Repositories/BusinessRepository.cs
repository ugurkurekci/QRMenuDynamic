using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public class BusinessRepository : IBusinessRepository
{

    private readonly AppDbContext _context;

    public BusinessRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Business business)
    {
        var entity = _context.Business.Add(business);
        await _context.SaveChangesAsync();
        return entity.Entity.Id;
    }

    public async Task<Business> Get(int id)
    {
        var result = await _context.Business.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (result == null)
        {
            return null;
        }
        return result;
    }

    public async Task<List<Business>> GetAll()
    {
        var result = await _context.Business.ToListAsync();
        if (result == null)
        {
            return null;
        }

        return result;
    }
}