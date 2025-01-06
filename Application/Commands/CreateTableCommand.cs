using Application.DTOs.Table;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Commands;

public class CreateTableCommand : IRequest<int>
{
    public CreateTableDto TableDto { get; set; }

    public CreateTableCommand(CreateTableDto tableDto)
    {
        TableDto = tableDto;
    }

    public class CreateTableCommandHandler : IRequestHandler<CreateTableCommand, int>
    {
        private readonly ITableRepository _tableRepository;
        private readonly IBusinessRepository _businessRepository;
        private readonly IMapper _mapper;

        public CreateTableCommandHandler(ITableRepository tableRepository, IMapper mapper, IBusinessRepository businessRepository)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
            _businessRepository = businessRepository;
        }

        public async Task<int> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var business = await _businessRepository.GetById(request.TableDto.BusinessId);
            if (business == null)
            {
                return 0;
            }
            Table table = _mapper.Map<Table>(request.TableDto);
            return await _tableRepository.Add(table);
        }
    }
}