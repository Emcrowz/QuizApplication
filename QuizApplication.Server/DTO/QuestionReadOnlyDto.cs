namespace QuizApplication.Server.DTO;

public record QuestionReadOnlyDto
{
    public string Title { get; init; }
    public IEnumerable<string>? Choises { get; init; }
    public IEnumerable<string>? CorrectOptions { get; init; }
    public int Points { get; init; }
}