using Application.DTOs.Role;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories.Interfaces;
using MediatR;

namespace Application.Commands.RoleCommand;

public class CreateRoleCommand : IRequest<int>
{
    public CreateRoleDto RoleDto { get; set; }

    public CreateRoleCommand(CreateRoleDto roleDto)
    {
        RoleDto = roleDto;
    }
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
        Role role = _mapper.Map<Role>(request.RoleDto);
        return await _roleRepository.Add(role);
    }
}