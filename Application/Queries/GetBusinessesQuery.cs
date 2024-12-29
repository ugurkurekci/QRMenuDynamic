using Application.DTOs.Business;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Queries;

public class GetBusinessesQuery : IRequest<IReadOnlyList<BusinessDto>> { }

public class GetBusinessesQueryHandler : IRequestHandler<GetBusinessesQuery, IReadOnlyList<BusinessDto>>
{
    private readonly IBusinessRepository _businessRepository;
    private readonly IMapper _mapper;
    public GetBusinessesQueryHandler(IBusinessRepository businessRepository, IMapper mapper)
    {
        _businessRepository = businessRepository;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<BusinessDto>> Handle(GetBusinessesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Business> businesses = await _businessRepository.GetAll();
        return _mapper.Map<IReadOnlyList<BusinessDto>>(businesses);
    }
}