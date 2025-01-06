using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface IBusinessRepository
{
    Task<int> Add(Business business);

    Task<Business> GetById(int id);

    Task<List<Business>> GetAll();
}