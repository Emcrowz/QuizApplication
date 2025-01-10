using QuizApplication.DataAccess.Models.Base;

namespace QuizApplication.DataAccess.Models;

public class Participant : AbstractModel
{
    public string Email { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public DateTime ParticipationDate { get; set; }
}