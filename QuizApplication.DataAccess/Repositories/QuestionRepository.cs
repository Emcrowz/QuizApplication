using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories.Base;
using QuizApplication.DataAccess.Repositories.Contracts;

namespace QuizApplication.DataAccess.Repositories;

public class QuestionRepository(QuizDbContext context) : AbstractRepository<Question>(context), IQuestionRepository
{
    
}