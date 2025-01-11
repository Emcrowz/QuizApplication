using Microsoft.AspNetCore.Mvc;
using QuizApplication.DataAccess.DTO;
using QuizApplication.DataAccess.Services.Contracts;

namespace QuizApplication.Server.Controllers;


[Route("[controller]")]
[ApiController]
public class ParticipantsController(IParticipantService service) : ControllerBase
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