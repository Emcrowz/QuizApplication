namespace QuizApplication.BusinessLogic.DTO;

public record ParticipantPostDto
{
    public string? Email { get; init; }
    public string? Name { get; init; }
    public DateTime ParticipationDate { get; init; }
    public string[][]? FinalAnswers { get; init; }
    public int Score { get; init; }
 }