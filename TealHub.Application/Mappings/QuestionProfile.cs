using AutoMapper;
using TealHub.Application.DTOs.Questions;
using TealHub.Domain.Entities;

namespace TealHub.Application.Mappings;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<Question, QuestionDto>();
    }
}