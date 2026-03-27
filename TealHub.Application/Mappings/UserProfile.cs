using AutoMapper;
using TealHub.Application.DTOs.Users;
using TealHub.Domain.Entities;

namespace TealHub.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}