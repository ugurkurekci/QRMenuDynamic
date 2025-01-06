using Application.DTOs.Business;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Commands;

public class CreateBusinessCommand : IRequest<int>
{
    public CreateBusinessDto BusinessDto { get; set; }

    public CreateBusinessCommand(CreateBusinessDto businessDto)
    {
        BusinessDto = businessDto;
    }
}

public class CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand, int>
{
    private readonly IBusinessRepository _businessRepository;
    private readonly IMapper _mapper;

    public CreateBusinessCommandHandler(IBusinessRepository businessRepository, IMapper mapper)
    {
        _businessRepository = businessRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
    {
        Business business = _mapper.Map<Business>(request.BusinessDto);
        return await _businessRepository.Add(business);
    }
}