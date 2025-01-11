using QuizApplication.DataAccess.Models;
using QuizApplication.Server.DTO;

namespace QuizApplication.Server.Helpers;

public static class ModelConverter
{
    public static T ConvertQuestionToReadOnlyDTO<T>(Question entity) where T : QuestionReadOnlyDto, new()
    {
        return new T()
        {
            Title = entity.Title,
            Choises = entity.Choises,
            CorrectOptions = entity.CorrectOptions,
            Points = entity.Points
        };
    }
}