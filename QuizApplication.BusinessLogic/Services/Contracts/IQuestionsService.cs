using QuizApplication.BusinessLogic.DTO;

namespace QuizApplication.BusinessLogic.Services.Contracts;

public interface IQuestionsService
{
    Task<IEnumerable<QuestionReadOnlyDto>> GetQuestionsAsync();
}