using QuizApplication.DataAccess.Models.Base;

namespace QuizApplication.DataAccess.Models;

public class Question : BaseModel
{
    public string Title { get; set; }
    public IEnumerable<string>? Choises { get; set; }
    public IEnumerable<string>? CorrectOptions { get; set; }
    public int Points { get; set; }
}