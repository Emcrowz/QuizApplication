using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories;
using QuizApplication.DataAccess.Repositories.Contracts;
using QuizApplication.DataAccess.Services.Contracts;

namespace QuizApplication.DataAccess.Services;

public class ParticipantService(QuizDbContext context) : IParticipantService
{
    private readonly IParticipantRepository _repository = new ParticipantRepository(context);

    public async Task<IEnumerable<Participant>> GetParticipantsAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task PostParticipantAsync(Participant entity)
    {
        await _repository.AddAsync(entity);
    }
}