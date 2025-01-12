namespace QuizApplication.DataAccess.DTO;

public class ParticipantReadOnlyDto
{
    public string Email { get; init; }
    public string Name { get; init; }
    public int Score { get; init; }
    public DateTime ParticipationDate { get; init; }
}