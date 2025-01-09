using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<int> Add(Order order);
}