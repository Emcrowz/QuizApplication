using Microsoft.AspNetCore.Mvc;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Services.Contracts;
using QuizApplication.Server.DTO;
using QuizApplication.Server.Helpers;

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

        List<ParticipantReadOnlyDto> data = [];
        foreach (Participant participant in res)
        {
            data.Add(ModelConverter.ConvertParticipantToReadOnlyDTO<ParticipantReadOnlyDto>(participant));
        }

        return TypedResults.Ok(data);
    }

    [HttpPost]
    public async Task<IResult> PostParticipant(ParticipantPostDto participant)
    {

        await service.PostParticipantAsync(ModelConverter.ConvertParticipantPostDtoToModel<Participant>(participant));

        return TypedResults.Ok();
    }
}