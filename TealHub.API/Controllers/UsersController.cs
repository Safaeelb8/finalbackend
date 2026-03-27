using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TealHub.Application.DTOs.Users;
using TealHub.Application.Services;

namespace TealHub.API.Controllers;

[ApiController]
[Route("api/users")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
    {
        var created = await _userService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserDto dto)
    {
        var updated = await _userService.UpdateAsync(id, dto);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _userService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }

    [HttpPatch("{id:guid}/role")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AssignRole(Guid id, [FromBody] string role)
    {
        var success = await _userService.AssignRoleAsync(id, role);
        return success ? Ok(new { message = "Role updated" }) : NotFound();
    }
}