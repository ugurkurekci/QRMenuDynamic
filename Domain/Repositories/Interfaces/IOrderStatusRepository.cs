using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface IOrderStatusRepository
{
    Task<List<OrderStatus>> GetAll();
}