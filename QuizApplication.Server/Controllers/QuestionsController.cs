using Microsoft.AspNetCore.Mvc;
using QuizApplication.BusinessLogic.Services.Contracts;

namespace QuizApplication.Server.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class QuestionsController(IQuestionsService service) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAll()
    {
        try
        {
            var res = await service.GetQuestionsAsync();
            if (!res.Any())
            {
                return TypedResults.NoContent();
            }

            return TypedResults.Ok(res);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(detail: ex.Message);
        }
    }
}
