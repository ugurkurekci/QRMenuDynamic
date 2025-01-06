using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<int> Register(User user);

    Task<User> Login(string email, string password);

    Task<User> GetByUserId(int userId);
}