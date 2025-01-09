using Domain.Data;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Concrete;

public class MenuCategoryRepository : IMenuCategoryRepository
{
    private readonly AppDbContext _context;

    public MenuCategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(MenuCategory menuCategory)
    {
        var entity = _context.MenuCategory.Add(menuCategory);
        await _context.SaveChangesAsync();
        return entity.Entity.Id;
    }

    public async Task<List<MenuCategory>> GetAll()
    {
        var menuCategories = await _context.MenuCategory.ToListAsync();
        if (menuCategories == null)
        {
            return new List<MenuCategory>();
        }
        return menuCategories;
    }
}