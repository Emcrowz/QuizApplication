using QuizApplication.BusinessLogic.DTO;

namespace QuizApplication.BusinessLogic.Services.Contracts;

public interface IParticipantsService
{
    Task<IEnumerable<ParticipantReadOnlyDto>> GetTop10ParticipantsForLeaderboardAsync();
    Task<int> PostParticipantAsync(ParticipantPostDto entity);
}