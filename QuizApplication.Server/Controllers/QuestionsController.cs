using Microsoft.AspNetCore.Mvc;
using QuizApplication.BusinessLogic.Services.Contracts;
using Serilog;

namespace QuizApplication.Server.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class QuestionsController(IQuestionsService service) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAll()
    {
        Log.Information($"[{nameof(GetAll)}] Attempt to GET a request.");
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
            Log.Error($"[{nameof(GetAll)}] Failed to GET a request with error: {ex.Message}.");
            return TypedResults.Problem(detail: ex.Message);
        }
    }
}
