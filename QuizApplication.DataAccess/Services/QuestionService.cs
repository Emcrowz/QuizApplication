using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories;
using QuizApplication.DataAccess.Repositories.Contracts;
using QuizApplication.DataAccess.Services.Contracts;

namespace QuizApplication.DataAccess.Services;

public class QuestionService(QuizDbContext context) : IQuestionService
{
    private readonly IQuestionRepository _repository = new QuestionRepository(context);

    public async Task<IEnumerable<Question>> GetQuestionsAsync()
    {
        return await _repository.GetAllAsync();
    }

}