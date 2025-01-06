using Application.DTOs.Business;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Queries;

public class GetAllBusinessQuery : IRequest<IReadOnlyList<BusinessDto>>
{ }

public class GetBusinessesQueryHandler : IRequestHandler<GetAllBusinessQuery, IReadOnlyList<BusinessDto>>
{
    private readonly IBusinessRepository _businessRepository;
    private readonly IMapper _mapper;

    public GetBusinessesQueryHandler(IBusinessRepository businessRepository, IMapper mapper)
    {
        _businessRepository = businessRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<BusinessDto>> Handle(GetAllBusinessQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Business> businesses = await _businessRepository.GetAll();
        return _mapper.Map<IReadOnlyList<BusinessDto>>(businesses);
    }
}