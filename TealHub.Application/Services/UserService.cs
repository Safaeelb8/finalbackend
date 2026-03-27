using AutoMapper;
using TealHub.Application.DTOs.Users;
using TealHub.Application.Interfaces;
using TealHub.Domain.Entities;

namespace TealHub.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public UserService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user == null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = dto.FullName,
            Email = dto.Email.ToLower().Trim(),
            PasswordHash = _passwordHasher.Hash(dto.Password),
            Role = dto.Role,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        var created = await _userRepository.CreateAsync(user);
        return _mapper.Map<UserDto>(created);
    }

    public async Task<UserDto?> UpdateAsync(Guid id, UpdateUserDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return null;

        user.FullName = dto.FullName;
        user.Email = dto.Email.ToLower().Trim();
        user.IsActive = dto.IsActive;

        var updated = await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserDto>(updated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        if (!await _userRepository.ExistsAsync(id)) return false;
        await _userRepository.DeleteAsync(id);
        return true;
    }

    public async Task<bool> AssignRoleAsync(Guid id, string role)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return false;
        user.Role = role;
        await _userRepository.UpdateAsync(user);
        return true;
    }
}