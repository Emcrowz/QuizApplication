using QuizApplication.DataAccess.DTO;

namespace QuizApplication.DataAccess.Services.Contracts;

public interface IParticipantService
{
    Task<IEnumerable<ParticipantReadOnlyDto>> GetParticipantsAsync();

    Task PostParticipantAsync(ParticipantPostDto entity);
}