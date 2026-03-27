using AutoMapper;
using TealHub.Application.DTOs.Documents;
using TealHub.Application.Interfaces;
using TealHub.Domain.Entities;

namespace TealHub.Application.Services;

public class DocumentService
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IMapper _mapper;

    public DocumentService(IDocumentRepository documentRepository, IMapper mapper)
    {
        _documentRepository = documentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DocumentDto>> GetAllAsync()
    {
        var docs = await _documentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DocumentDto>>(docs);
    }

    public async Task<DocumentDto?> GetByIdAsync(Guid id)
    {
        var doc = await _documentRepository.GetByIdAsync(id);
        return doc == null ? null : _mapper.Map<DocumentDto>(doc);
    }

    public async Task<IEnumerable<DocumentDto>> SearchAsync(string keyword)
    {
        var docs = await _documentRepository.SearchAsync(keyword);
        return _mapper.Map<IEnumerable<DocumentDto>>(docs);
    }

    public async Task<DocumentDto> UploadAsync(UploadDocumentDto dto)
    {
        var document = new Document
        {
            Id = Guid.NewGuid(),
            Title = dto.Title,
            Description = dto.Description,
            FilePath = dto.FilePath,
            FileType = dto.FileType,
            FileSize = dto.FileSize,
            UploadedByUserId = dto.UploadedByUserId,
            UploadedAt = DateTime.UtcNow
        };

        var created = await _documentRepository.CreateAsync(document);
        return _mapper.Map<DocumentDto>(created);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var doc = await _documentRepository.GetByIdAsync(id);
        if (doc == null) return false;
        await _documentRepository.DeleteAsync(id);
        return true;
    }
}