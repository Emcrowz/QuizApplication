using Microsoft.AspNetCore.Mvc;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.DataAccess.DTO;

namespace QuizApplication.Server.Controllers;


[Route("[controller]")]
[ApiController]
public class ParticipantsController(IParticipantsService service) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetParticipants()
    {
        var res = await service.GetParticipantsAsync();
        if (!res.Any())
        {
            return TypedResults.NoContent();
        }

        return TypedResults.Ok(res);
    }

    [HttpPost]
    public async Task<IResult> PostParticipant(ParticipantPostDto participant)
    {
        await service.PostParticipantAsync(participant);

        return TypedResults.Ok();
    }
}