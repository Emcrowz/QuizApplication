using QuizApplication.DataAccess.Models;

namespace QuizApplication.DataAccess.Services.Contracts;

public interface IQuestionService
{
    Task<IEnumerable<Question>> GetQuestionsAsync();
}