using Domain.Data;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Concrete;

public class RoleRepository : IRoleRepository
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Role role)
    {
        var entity = _context.Role.Add(role);
        await _context.SaveChangesAsync();
        return entity.Entity.Id;
    }

    public async Task<List<Role>> GetAllAsync()
    {
        return await _context.Role.ToListAsync();
    }
}