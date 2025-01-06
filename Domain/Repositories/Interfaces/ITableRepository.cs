using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface ITableRepository
{
    Task<int> Add(Table table);

    Task<Table> GetByQRCode(string qrCode);

    Task<Table> GetById(int id);

    Task<List<Table>> GetAll();
}