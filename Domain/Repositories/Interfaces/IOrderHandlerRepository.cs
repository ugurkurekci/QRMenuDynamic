using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface IOrderHandlerRepository
{

    Task<int> Add(OrderHandler orderHandler);

}