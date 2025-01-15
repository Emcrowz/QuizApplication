using QuizApplication.DataAccess.Constants;

namespace QuizApplication.BusinessLogic.DTO;

public record QuestionReadOnlyDto
{
    public QuestionType Type { get; init; }
    public string? Title { get; init; }
    public IEnumerable<string>? Choises { get; init; }
}