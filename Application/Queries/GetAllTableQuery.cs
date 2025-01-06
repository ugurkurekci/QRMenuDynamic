using Application.DTOs.Table;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Queries;

public class GetAllTableQuery : IRequest<IReadOnlyList<TableDto>> { }

public class GetAllTableQueryHandler : IRequestHandler<GetAllTableQuery, IReadOnlyList<TableDto>>
{
    private readonly ITableRepository _tableRepository;
    private readonly IMapper _mapper;

    public GetAllTableQueryHandler(ITableRepository tableRepository, IMapper mapper)
    {
        _tableRepository = tableRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<TableDto>> Handle(GetAllTableQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Table> tables = await _tableRepository.GetAll();
        return _mapper.Map<IReadOnlyList<TableDto>>(tables);
    }
}