using Application.DTOs.MenuCategory;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.MenuCategoryQuery;

public class GetAllMenuCategoryQuery : IRequest<IReadOnlyList<MenuCategoryDto>>
{ }

public class GetAllMenuCategoryQueryHandler : IRequestHandler<GetAllMenuCategoryQuery, IReadOnlyList<MenuCategoryDto>>
{
    private readonly IMenuCategoryRepository _menuCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllMenuCategoryQueryHandler(IMenuCategoryRepository menuCategoryRepository, IMapper mapper)
    {
        _menuCategoryRepository = menuCategoryRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<MenuCategoryDto>> Handle(GetAllMenuCategoryQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<MenuCategory> menuCategories = await _menuCategoryRepository.GetAll();
        return _mapper.Map<IReadOnlyList<MenuCategoryDto>>(menuCategories);
    }
}