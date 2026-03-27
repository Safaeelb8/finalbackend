using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TealHub.Application.Services;

namespace TealHub.API.Controllers;

[ApiController]
[Route("api/logs")]
[Authorize(Roles = "Admin")]
public class LogsController : ControllerBase
{
    private readonly LogService _logService;

    public LogsController(LogService logService)
    {
        _logService = logService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var logs = await _logService.GetAllAsync();
        return Ok(logs);
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetByUser(Guid userId)
    {
        var logs = await _logService.GetByUserAsync(userId);
        return Ok(logs);
    }

    [HttpGet("export")]
    public async Task<IActionResult> Export()
    {
        var logs = await _logService.GetAllAsync();
        var csv = "Id,Action,Details,Timestamp,IpAddress,UserId\n" +
                  string.Join("\n", logs.Select(l =>
                      $"{l.Id},{l.Action},{l.Details},{l.Timestamp},{l.IpAddress},{l.UserId}"));

        return File(System.Text.Encoding.UTF8.GetBytes(csv),
            "text/csv", $"logs_{DateTime.UtcNow:yyyyMMdd}.csv");
    }
}
