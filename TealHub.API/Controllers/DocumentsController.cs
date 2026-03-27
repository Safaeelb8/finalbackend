using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TealHub.Application.DTOs.Documents;
using TealHub.Application.Services;

namespace TealHub.API.Controllers;

[ApiController]
[Route("api/documents")]
[Authorize]
public class DocumentsController : ControllerBase
{
    private readonly DocumentService _documentService;

    public DocumentsController(DocumentService documentService)
    {
        _documentService = documentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var docs = await _documentService.GetAllAsync();
        return Ok(docs);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var doc = await _documentService.GetByIdAsync(id);
        return doc == null ? NotFound() : Ok(doc);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string keyword)
    {
        var docs = await _documentService.SearchAsync(keyword);
        return Ok(docs);
    }

    [HttpPost]
    public async Task<IActionResult> Upload([FromBody] UploadDocumentDto dto)
    {
        var created = await _documentService.UploadAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _documentService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}