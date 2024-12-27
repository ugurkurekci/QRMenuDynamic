using Application.DTOs.Role;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Commands;

public class CreateRoleCommand : IRequest<int>
{
    public CreateRoleDto RoleDto { get; set; }
}

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
{

    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = _mapper.Map<Role>(request.RoleDto);
        return await _roleRepository.Add(role);
    }

}