using Application.DTOs.Business;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Queries;

public class GetBusinessQuery : IRequest<BusinessDto>
{
    public int Id { get; set; }
    public GetBusinessQuery(int id)
    {
        Id = id;
    }
}

public class GetBusinessQueryHandler : IRequestHandler<GetBusinessQuery, BusinessDto>
{
    private readonly IBusinessRepository _businessRepository;
    private readonly IMapper _mapper;
    public GetBusinessQueryHandler(IBusinessRepository businessRepository, IMapper mapper)
    {
        _businessRepository = businessRepository;
        _mapper = mapper;
    }
    public async Task<BusinessDto> Handle(GetBusinessQuery request, CancellationToken cancellationToken)
    {
        Business business = await _businessRepository.Get(request.Id);
        return _mapper.Map<BusinessDto>(business);
    }
}