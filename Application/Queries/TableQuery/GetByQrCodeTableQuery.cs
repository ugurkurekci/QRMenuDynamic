using Application.DTOs.Table;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Queries.TableQuery;

public class GetByQrCodeTableQuery : IRequest<TableDto>
{
    public string QrCode { get; set; }

    public GetByQrCodeTableQuery(string qrCode)
    {
        QrCode = qrCode;
    }
}

public class GetByQRCodeTableQueryHandler : IRequestHandler<GetByQrCodeTableQuery, TableDto>
{
    private readonly ITableRepository _tableRepository;
    private readonly IMapper _mapper;

    public GetByQRCodeTableQueryHandler(ITableRepository tableRepository, IMapper mapper)
    {
        _tableRepository = tableRepository;
        _mapper = mapper;
    }

    public async Task<TableDto> Handle(GetByQrCodeTableQuery request, CancellationToken cancellationToken)
    {
        Table table = await _tableRepository.GetByQRCode(request.QrCode);
        return _mapper.Map<TableDto>(table);
    }
}