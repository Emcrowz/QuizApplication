using QuizApplication.DataAccess.Models.Base;

namespace QuizApplication.DataAccess.Models;

public class Question : AbstractModel
{
    public string Title { get; set; }
    public IEnumerable<string>? Choises { get; set; }
    public string Solution { get; set; }
    public int Points { get; set; }
}