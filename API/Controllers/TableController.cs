using Application.Commands;
using Application.DTOs.Table;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TableController : BaseController
{
    private readonly IMediator _mediator;

    public TableController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<int>> CreateTable([FromBody] CreateTableDto tableDto)
    {
        var result = await _mediator.Send(new CreateTableCommand(tableDto));
        if (result == 0)
        {
            return BadRequest();
        }
        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IReadOnlyList<TableDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllTableQuery());
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<TableDto>> GetById(int id)
    {
        var result = await _mediator.Send(new GetByIdTableQuery(id));
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("qr/{qrCode}")]
    [AllowAnonymous]
    public async Task<ActionResult<TableDto>> GetByQrCode(string qrCode)
    {
        var result = await _mediator.Send(new GetByQrCodeTableQuery(qrCode));
        if (result == null)
        {
            object error = new { message = "Table not found" };
            return NotFound(error);
        }
        return Ok(result);
    }
}