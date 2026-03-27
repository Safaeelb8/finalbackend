using AutoMapper;
using TealHub.Application.DTOs.Documents;
using TealHub.Domain.Entities;

namespace TealHub.Application.Mappings;

public class DocumentProfile : Profile
{
    public DocumentProfile()
    {
        CreateMap<Document, DocumentDto>();
    }
}