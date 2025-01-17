using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories.Base;
using QuizApplication.DataAccess.Repositories.Contracts;

namespace QuizApplication.DataAccess.Repositories;

public class ParticipantRepository : AbstractRepository<Participant>, IParticipantRepository
{
    public ParticipantRepository(QuizDbContext context) : base (context)
    {
        context.Database.EnsureCreatedAsync();
    }
}