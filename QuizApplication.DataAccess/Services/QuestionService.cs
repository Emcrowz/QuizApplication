using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.DTO;
using QuizApplication.DataAccess.Helpers;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories;
using QuizApplication.DataAccess.Repositories.Contracts;
using QuizApplication.DataAccess.Services.Contracts;

namespace QuizApplication.DataAccess.Services;

public class QuestionService(QuizDbContext context) : IQuestionService
{
    private readonly IQuestionRepository _repository = new QuestionRepository(context);

    public async Task<IEnumerable<QuestionReadOnlyDto>> GetQuestionsAsync()
    {
        var data = await _repository.GetAllAsync();

        List<QuestionReadOnlyDto> dtos = [];
        foreach (Question question in data)
        {
            dtos.Add(ModelConverter.ConvertQuestionToReadOnlyDTO<QuestionReadOnlyDto>(question));
        }

        return dtos;
    }

}