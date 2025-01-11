using QuizApplication.DataAccess.DTO;

namespace QuizApplication.DataAccess.Services.Contracts;

public interface IQuestionService
{
    Task<IEnumerable<QuestionReadOnlyDto>> GetQuestionsAsync();
}