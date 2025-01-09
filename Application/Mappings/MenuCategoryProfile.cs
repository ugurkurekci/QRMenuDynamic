using Application.DTOs.MenuCategory;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class MenuCategoryProfile : Profile
{
    public MenuCategoryProfile()
    {
        CreateMap<MenuCategory, MenuCategoryDto>();
        CreateMap<CreateMenuCategoryDto, MenuCategory>();
    }
}