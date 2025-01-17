using Microsoft.AspNetCore.Mvc;
using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Services.Contracts;
using Serilog;

namespace QuizApplication.Server.Controllers;


[Route("[controller]/[action]")]
[ApiController]
public class ParticipantsController(IParticipantsService service) : ControllerBase
{
    [HttpPost]
    public async Task<IResult> PostSingle(ParticipantPostDto participant)
    {
        Log.Information($"[{nameof(PostSingle)}] Attempt to POST a request of type {nameof(ParticipantReadOnlyDto)}");
        try
        {
            if (string.IsNullOrWhiteSpace(participant.Name) || string.IsNullOrWhiteSpace(participant.Email))
            {
                return TypedResults.BadRequest();
            }

            var res = await service.PostParticipantAsync(participant);

            return TypedResults.Ok(res);
        }
        catch (Exception ex)
        {
            Log.Error($"[{nameof(PostSingle)}] Failed to POST a request of type {nameof(ParticipantReadOnlyDto)} with error: {ex.Message}.");
            return TypedResults.Problem(detail: ex.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetTop()
    {
        Log.Information($"[{nameof(GetTop)}] Attempt to GET a request.");
        try
        {
            var res = await service.GetTop10ParticipantsForLeaderboardAsync();
            if (!res.Any())
            {
                return TypedResults.NoContent();
            }

            return TypedResults.Ok(res);
        }
        catch (Exception ex)
        {
            Log.Error($"[{nameof(GetTop)}] Failed to GET a request with error: {ex.Message}.");
            return TypedResults.Problem(detail: ex.Message);
        }
    }
}