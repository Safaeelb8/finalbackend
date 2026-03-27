using AutoMapper;
using TealHub.Application.DTOs.Logs;
using TealHub.Domain.Entities;

namespace TealHub.Application.Mappings;

public class LogProfile : Profile
{
    public LogProfile()
    {
        CreateMap<Log, LogDto>();
    }
}