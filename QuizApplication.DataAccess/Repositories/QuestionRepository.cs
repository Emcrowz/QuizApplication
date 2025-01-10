using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Contracts;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories.Base;

namespace QuizApplication.DataAccess.Repositories;

public class QuestionRepository(QuizDbContext context) : AbstractRepository<Question>(context), IQuestionRepository
{
    
}