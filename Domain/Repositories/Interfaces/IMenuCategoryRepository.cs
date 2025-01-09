using Domain.Entities;

namespace Domain.Repositories.Interfaces;

public interface IMenuCategoryRepository
{
    Task<int> Add(MenuCategory menuCategory);

    Task<List<MenuCategory>> GetAll();
}