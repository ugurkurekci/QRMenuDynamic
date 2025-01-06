using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface IRoleRepository
{
    Task<List<Role>> GetAllAsync();

    Task<int> Add(Role role);
}