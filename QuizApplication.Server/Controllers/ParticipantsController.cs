using Microsoft.AspNetCore.Mvc;
using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Services.Contracts;

namespace QuizApplication.Server.Controllers;


[Route("[controller]/[action]")]
[ApiController]
public class ParticipantsController(IParticipantsService service) : ControllerBase
{
    [HttpPost]
    public async Task<IResult> PostSingle(ParticipantPostDto participant)
    {
        try
        {
            if (participant == null || string.IsNullOrWhiteSpace(participant.Name) || string.IsNullOrWhiteSpace(participant.Email))
            {
                return TypedResults.BadRequest();
            }

            var res = await service.PostParticipantAsync(participant);

            return TypedResults.Ok(res);
        }
        catch (Exception ex)
        {
            return TypedResults.Problem(detail: ex.Message);
        }
    }

    [HttpGet]
    public async Task<IResult> GetTop()
    {
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
            return TypedResults.Problem(detail: ex.Message);
        }
    }
}