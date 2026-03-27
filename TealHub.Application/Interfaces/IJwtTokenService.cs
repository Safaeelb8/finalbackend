using TealHub.Domain.Entities;

namespace TealHub.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}