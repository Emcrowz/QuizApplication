using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Contracts;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories.Base;

namespace QuizApplication.DataAccess.Repositories;

public class ParticipantRepository(QuizDbContext context) : AbstractRepository<Participant>(context), IParticipantRepository
{
    
}