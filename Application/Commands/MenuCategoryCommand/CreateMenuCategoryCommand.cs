using Application.DTOs.MenuCategory;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Commands.MenuCategoryCommand;

public class CreateMenuCategoryCommand : IRequest<int>
{
    public CreateMenuCategoryDto CreateMenuCategoryDto { get; set; }

    public CreateMenuCategoryCommand(CreateMenuCategoryDto createMenuCategoryDto)
    {
        CreateMenuCategoryDto = createMenuCategoryDto;
    }
}

public class CreateMenuCategoryCommandHandler : IRequestHandler<CreateMenuCategoryCommand, int>
{
    private readonly IMenuCategoryRepository _menuCategoryRepository;
    private readonly IMapper _mapper;
    public CreateMenuCategoryCommandHandler(IMenuCategoryRepository menuCategoryRepository, IMapper mapper)
    {
        _menuCategoryRepository = menuCategoryRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateMenuCategoryCommand request, CancellationToken cancellationToken)
    {
        MenuCategory menuCategory = _mapper.Map<MenuCategory>(request.CreateMenuCategoryDto);
        return await _menuCategoryRepository.Add(menuCategory);
    }
}