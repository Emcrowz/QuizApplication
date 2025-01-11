namespace QuizApplication.DataAccess.DTO;

public record ParticipantPostDto
{
    public string Email { get; init; }
    public string Name { get; init; }
    public int Score { get; init; }
    public DateTime ParticipationDate { get; init; } = DateTime.Now;
}