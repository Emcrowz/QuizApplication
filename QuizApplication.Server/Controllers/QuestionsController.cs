using Microsoft.AspNetCore.Mvc;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Services.Contracts;
using QuizApplication.Server.DTO;
using QuizApplication.Server.Helpers;

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

        List<QuestionReadOnlyDto> data = [];
        foreach (Question question in res)
        {
            data.Add(ModelConverter.ConvertQuestionToReadOnlyDTO<QuestionReadOnlyDto>(question));
        }

        return TypedResults.Ok(data);
    }
}
