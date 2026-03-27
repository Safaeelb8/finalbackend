using Microsoft.AspNetCore.Mvc;
using TealHub.Application.DTOs.Auth;
using TealHub.Application.Services;

namespace TealHub.API.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
    {
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        var result = await _authService.LoginAsync(dto, ipAddress);

        if (result == null)
            return Unauthorized(new { message = "Invalid email or password" });

        return Ok(result);
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        // JWT is stateless — client discards token
        return Ok(new { message = "Logged out successfully" });
    }
}