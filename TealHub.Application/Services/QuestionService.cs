using AutoMapper;
using TealHub.Application.DTOs.Questions;
using TealHub.Application.Interfaces;
using TealHub.Domain.Entities;

namespace TealHub.Application.Services;

public class QuestionService
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<QuestionDto> SubmitAsync(CreateQuestionDto dto)
    {
        var question = new Question
        {
            Id = Guid.NewGuid(),
            Content = dto.Content,
            UserId = dto.UserId,
            AskedAt = DateTime.UtcNow
        };

        var created = await _questionRepository.CreateAsync(question);
        return _mapper.Map<QuestionDto>(created);
    }

    public async Task<IEnumerable<QuestionDto>> GetHistoryAsync(Guid userId)
    {
        var questions = await _questionRepository.GetHistoryByUserAsync(userId);
        return _mapper.Map<IEnumerable<QuestionDto>>(questions);
    }

    public async Task<QuestionDto?> GetByIdAsync(Guid id)
    {
        var question = await _questionRepository.GetByIdAsync(id);
        return question == null ? null : _mapper.Map<QuestionDto>(question);
    }
}