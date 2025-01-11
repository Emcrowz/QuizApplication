using QuizApplication.DataAccess.Models.Base;

namespace QuizApplication.DataAccess.Models;

public enum QuestionType : byte
{
    Typed = 0,
    Single = 1,
    Multiple = 2
}

public class Question : BaseModel
{
    public QuestionType Type { get; set; }
    public string Title { get; set; }
    public IEnumerable<string>? Choises { get; set; }
    public IEnumerable<string>? CorrectOptions { get; set; }
    public int Points { get; set; }
}