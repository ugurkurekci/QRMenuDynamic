using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface IOrderDetailRepository
{
    Task<int> Add(OrderDetail orderDetail);
}