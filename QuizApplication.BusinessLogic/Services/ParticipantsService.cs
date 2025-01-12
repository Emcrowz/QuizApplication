using QuizApplication.BusinessLogic.Helpers;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.DTO;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories;
using QuizApplication.DataAccess.Repositories.Contracts;

namespace QuizApplication.BusinessLogic.Services;

public class ParticipantsService(QuizDbContext context) : IParticipantsService
{
    private readonly IParticipantRepository _repository = new ParticipantRepository(context);

    public async Task<IEnumerable<ParticipantReadOnlyDto>> GetParticipantsAsync()
    {
        var data = await _repository.GetAllAsync();

        List<ParticipantReadOnlyDto> dtos = [];
        foreach (Participant participant in data)
        {
            dtos.Add(ModelConverter.ConvertParticipantToReadOnlyDTO<ParticipantReadOnlyDto>(participant));
        }

        return dtos;
    }

    public async Task PostParticipantAsync(ParticipantPostDto entity)
    {
        var data = ModelConverter.ConvertParticipantPostDtoToModel<Participant>(entity);

        await _repository.AddAsync(data);
    }
}