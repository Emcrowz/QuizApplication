using QuizApplication.DataAccess.Models;

namespace QuizApplication.DataAccess.Services.Contracts;

public interface IParticipantService
{
    Task<IEnumerable<Participant>> GetParticipantsAsync();

    Task PostParticipantAsync(Participant entity);
}