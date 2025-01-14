using Microsoft.AspNetCore.Mvc;
using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Services.Contracts;

namespace QuizApplication.Server.Controllers;


[Route("[controller]/[action]")]
[ApiController]
public class ParticipantsController(IParticipantsService service) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetAll()
    {
        var res = await service.GetParticipantsAsync();
        if (!res.Any())
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(res);
    }

    [HttpPost]
    public async Task<IResult> PostSingle(ParticipantPostDto participant)
    {
        await service.PostParticipantAsync(participant);

        return TypedResults.Ok();
    }

    [HttpGet]
    public async Task<IResult> GetTop()
    {
        var res = await service.GetTop10ParticipantsForLeaderboardAsync();
        if (!res.Any())
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(res);
    }
}