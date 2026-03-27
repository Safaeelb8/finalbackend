using AutoMapper;
using TealHub.Application.DTOs.Logs;
using TealHub.Application.Interfaces;

namespace TealHub.Application.Services;

public class LogService
{
    private readonly ILogRepository _logRepository;
    private readonly IMapper _mapper;

    public LogService(ILogRepository logRepository, IMapper mapper)
    {
        _logRepository = logRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LogDto>> GetAllAsync()
    {
        var logs = await _logRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<LogDto>>(logs);
    }

    public async Task<IEnumerable<LogDto>> GetByUserAsync(Guid userId)
    {
        var logs = await _logRepository.GetByUserAsync(userId);
        return _mapper.Map<IEnumerable<LogDto>>(logs);
    }
}