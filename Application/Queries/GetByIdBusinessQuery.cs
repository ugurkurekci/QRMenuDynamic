using Application.DTOs.Business;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Queries;

public class GetByIdBusinessQuery : IRequest<BusinessDto>
{
    public int Id { get; set; }

    public GetByIdBusinessQuery(int id)
    {
        Id = id;
    }
}

public class GetBusinessQueryHandler : IRequestHandler<GetByIdBusinessQuery, BusinessDto>
{
    private readonly IBusinessRepository _businessRepository;
    private readonly IMapper _mapper;

    public GetBusinessQueryHandler(IBusinessRepository businessRepository, IMapper mapper)
    {
        _businessRepository = businessRepository;
        _mapper = mapper;
    }

    public async Task<BusinessDto> Handle(GetByIdBusinessQuery request, CancellationToken cancellationToken)
    {
        Business business = await _businessRepository.GetById(request.Id);
        return _mapper.Map<BusinessDto>(business);
    }
}