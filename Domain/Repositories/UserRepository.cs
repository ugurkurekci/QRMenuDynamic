using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public class UserRepository : IUserRepository
{

    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByUserId(int userId)
    {
        var result = await _context.User.Where(u => u.Id == userId).FirstOrDefaultAsync();
        if (result == null)
        {
            return null;
        }

        return result;
    }

    public async Task<User> Login(string email, string password)
    {
        var result = await _context.User.Where(u => u.EMail == email && u.Password == password).FirstOrDefaultAsync();
        if (result == null)
        {
            return null;
        }

        return result;
    }

    public async Task<int> Register(User user)
    {
        var entity = _context.User.Add(user);
        await _context.SaveChangesAsync();
        return entity.Entity.Id;
    }

}