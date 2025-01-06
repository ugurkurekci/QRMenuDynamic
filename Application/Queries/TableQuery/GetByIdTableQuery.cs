using Application.DTOs.Table;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.TableQuery;

public class GetByIdTableQuery : IRequest<TableDto>
{
    public int Id { get; set; }

    public GetByIdTableQuery(int id)
    {
        Id = id;
    }
}

public class GetByIdTableQueryHandler : IRequestHandler<GetByIdTableQuery, TableDto>
{
    private readonly ITableRepository _tableRepository;
    private readonly IMapper _mapper;

    public GetByIdTableQueryHandler(ITableRepository tableRepository, IMapper mapper)
    {
        _tableRepository = tableRepository;
        _mapper = mapper;
    }

    public async Task<TableDto> Handle(GetByIdTableQuery request, CancellationToken cancellationToken)
    {
        Table table = await _tableRepository.GetById(request.Id);
        return _mapper.Map<TableDto>(table);
    }
}