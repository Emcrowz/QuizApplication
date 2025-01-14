using QuizApplication.BusinessLogic.DTO;

namespace QuizApplication.BusinessLogic.Services.Contracts;

public interface IParticipantsService
{
    Task<IEnumerable<ParticipantReadOnlyDto>> GetParticipantsAsync();
    Task<IEnumerable<ParticipantReadOnlyDto>> GetTop10ParticipantsForLeaderboardAsync();
    Task PostParticipantAsync(ParticipantPostDto entity);
}