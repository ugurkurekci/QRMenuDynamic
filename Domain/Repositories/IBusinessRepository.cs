using Domain.Entities;

namespace Domain.Repositories;

public interface IBusinessRepository
{

    Task<int> Add(Business business);

    Task<Business> Get(int id);

    Task<List<Business>> GetAll();

}