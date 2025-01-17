using QuizApplication.BusinessLogic.DTO;
using QuizApplication.DataAccess.Models;

namespace QuizApplication.BusinessLogic.Helpers;

public static class ModelConverter
{
    public static QuestionReadOnlyDto ConvertQuestionToReadOnlyDTO(Question entity)
    {
        return new QuestionReadOnlyDto()
        {
            Type = entity.Type,
            Title = entity.Title,
            Choises = entity.Choises,
        };
    }

    public static ParticipantReadOnlyDto ConvertParticipantToReadOnlyDTO(Participant entity)
    {
        return new ParticipantReadOnlyDto()
        {
            Email = entity.Email,
            Name = entity.Name,
            ParticipationDate = entity.ParticipationDate,
            Score = entity.Score
        };
    }

    public static Participant ConvertParticipantPostDtoToModel(ParticipantPostDto entity)
    {
        return new Participant()
        {
            Id = 0,
            Email = string.IsNullOrWhiteSpace(entity.Email) ? "Anonymous" : entity.Email,
            Name = string.IsNullOrWhiteSpace(entity.Name) ? "Anonymous" : entity.Name,
            ParticipationDate = entity.ParticipationDate,
            Score = entity.Score
        };
    }

    public static IEnumerable<QuestionReadOnlyDto> ConvertQuestionsToDtos(IEnumerable<Question> questions)
    {
        List<QuestionReadOnlyDto> dtos = [];
        foreach (Question question in questions)
        {
            dtos.Add(ConvertQuestionToReadOnlyDTO(question));
        }

        return dtos;
    }

    public static IEnumerable<ParticipantReadOnlyDto> ConvertParticipantsToDtos(IEnumerable<Participant> participants)
    {
        List<ParticipantReadOnlyDto> dtos = [];
        foreach (Participant participant in participants)
        {
            dtos.Add(ConvertParticipantToReadOnlyDTO(participant));
        }

        return dtos;
    }
}