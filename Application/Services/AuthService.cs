using Application.DTOs.Auth;
using AutoMapper;
using Core.Services;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services;

public class AuthService : IAuthService

{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IMapper _mapper;

    public AuthService(IUserRepository userRepository, IMapper mapper, IJwtTokenService jwtTokenService)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<AuthResponse> Login(string email, string password)
    {

        var user = await _userRepository.Login(email, password);
        if (user == null)
        {
            return null;
        }

        var token = _jwtTokenService.GenerateToken(user.Id, user.EMail, user.RoleId);

        return new AuthResponse
        {
            UserId = user.Id,
            Email = user.EMail,
            Role = user.RoleId,
            RoleId = user.RoleId,
            Token = token
        };
    }

    public Task<int> Register(RegisterDto dto)
    {
        User user = _mapper.Map<User>(dto);
        return _userRepository.Register(user);
    }
}