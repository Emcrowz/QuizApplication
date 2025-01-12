using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Helpers;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories;
using QuizApplication.DataAccess.Repositories.Contracts;

namespace QuizApplication.BusinessLogic.Services;

public class QuestionsService(QuizDbContext context) : IQuestionsService
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