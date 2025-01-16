using QuizApplication.DataAccess.Constants;
using QuizApplication.DataAccess.Models.Base;

namespace QuizApplication.DataAccess.Models;

public class Question : BaseModel
{
    public QuestionType Type { get; set; }
    public required string Title { get; set; }
    public IEnumerable<string>? Choises { get; set; }
    public IEnumerable<string>? CorrectOptions { get; set; }
    public int Points { get; set; }
}