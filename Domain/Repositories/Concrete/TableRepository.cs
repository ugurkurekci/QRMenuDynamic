using Domain.Data;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Concrete;

public class TableRepository : ITableRepository
{
    private readonly AppDbContext _context;

    public TableRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(Table table)
    {
        var entity = _context.Table.Add(table);
        await _context.SaveChangesAsync();
        return entity.Entity.Id;
    }

    public async Task<List<Table>> GetAll()
    {
        var result = await _context.Table.ToListAsync();
        if (result == null)
        {
            return null;
        }

        return result;
    }

    public async Task<Table> GetById(int id)
    {
        var result = await _context.Table.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (result == null)
        {
            return null;
        }
        return result;
    }

    public async Task<Table> GetByQRCode(string qrCode)
    {
        var result = await _context.Table.Where(x => x.QrCode == qrCode).FirstOrDefaultAsync();
        if (result == null)
        {
            return null;
        }
        return result;
    }
}