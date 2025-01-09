using Application.Commands.MenuCategoryCommand;
using Application.DTOs.MenuCategory;
using Application.Queries.MenuCategoryQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MenuCategoryController : BaseController
{
    private readonly IMediator _mediator;

    public MenuCategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet, AllowAnonymous]
    public async Task<ActionResult<IReadOnlyList<MenuCategoryDto>>> GetAllMenuCategories()
    {
        return Ok(await _mediator.Send(new GetAllMenuCategoryQuery()));
    }

    [HttpPost, AllowAnonymous]
    public async Task<ActionResult<int>> CreateMenuCategory(CreateMenuCategoryDto createMenuCategoryDto)
    {
        return Ok(await _mediator.Send(new CreateMenuCategoryCommand(createMenuCategoryDto)));
    }
}