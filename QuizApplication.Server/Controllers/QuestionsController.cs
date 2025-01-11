using Microsoft.AspNetCore.Mvc;
using QuizApplication.DataAccess.Services.Contracts;

namespace QuizApplication.Server.Controllers;

[Route("[controller]")]
[ApiController]
public class QuestionsController(IQuestionService service) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetQuestions()
    {
        var res = await service.GetQuestionsAsync();
        if (!res.Any())
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(res);
    }
}
