using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories;
using QuizApplication.DataAccess.Repositories.Contracts;
using QuizApplication.DataAccess.Services.Contracts;

namespace QuizApplication.DataAccess.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository repository;

    public QuestionService(QuizDbContext context)
    {
        repository = new QuestionRepository(context);
    }


    public async Task<IEnumerable<Question>> GetQuestionsAsync()
    {
        return await repository.GetAllAsync();
    }

}