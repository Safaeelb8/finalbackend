using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TealHub.Application.DTOs.Questions;
using TealHub.Application.Services;

namespace TealHub.API.Controllers;

[ApiController]
[Route("api/questions")]
[Authorize]
public class QuestionsController : ControllerBase
{
    private readonly QuestionService _questionService;

    public QuestionsController(QuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpPost]
    public async Task<IActionResult> Submit([FromBody] CreateQuestionDto dto)
    {
        var created = await _questionService.SubmitAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var question = await _questionService.GetByIdAsync(id);
        return question == null ? NotFound() : Ok(question);
    }

    [HttpGet("history/{userId:guid}")]
    public async Task<IActionResult> GetHistory(Guid userId)
    {
        var history = await _questionService.GetHistoryAsync(userId);
        return Ok(history);
    }
}
