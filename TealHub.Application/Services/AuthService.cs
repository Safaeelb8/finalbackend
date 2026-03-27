using TealHub.Application.DTOs.Auth;
using TealHub.Application.Interfaces;
using TealHub.Domain.Entities;

namespace TealHub.Application.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ILogRepository _logRepository;

    public AuthService(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenService,
        IPasswordHasher passwordHasher,
        ILogRepository logRepository)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
        _passwordHasher = passwordHasher;
        _logRepository = logRepository;
    }

    public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto, string ipAddress)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null || !user.IsActive)
            return null;

        if (!_passwordHasher.Verify(dto.Password, user.PasswordHash))
            return null;

        await _logRepository.CreateAsync(new Log
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Action = "LOGIN",
            Details = $"User {user.Email} logged in",
            IpAddress = ipAddress,
            Timestamp = DateTime.UtcNow
        });

        return new AuthResponseDto
        {
            Token = _jwtTokenService.GenerateToken(user),
            FullName = user.FullName,
            Email = user.Email,
            Role = user.Role
        };
    }
}