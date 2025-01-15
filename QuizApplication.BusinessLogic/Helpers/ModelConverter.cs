using QuizApplication.BusinessLogic.DTO;
using QuizApplication.DataAccess.Models;

namespace QuizApplication.BusinessLogic.Helpers;

public static class ModelConverter
{
    public static T ConvertQuestionToReadOnlyDTO<T>(Question entity) where T : QuestionReadOnlyDto, new()
    {
        return new T()
        {
            Type = entity.Type,
            Title = entity.Title,
            Choises = entity.Choises,
        };
    }

    public static T ConvertParticipantToReadOnlyDTO<T>(Participant entity) where T : ParticipantReadOnlyDto, new()
    {
        return new T()
        {
            Email = entity.Email,
            Name = entity.Name,
            ParticipationDate = entity.ParticipationDate,
            Score = entity.Score
        };
    }

    public static T ConvertParticipantPostDtoToModel<T>(ParticipantPostDto entity) where T : Participant, new()
    {
        return new T()
        {
            Id = 0,
            Email = string.IsNullOrWhiteSpace(entity.Email) ? "Anonymous" : entity.Email,
            Name = string.IsNullOrWhiteSpace(entity.Name) ? "Anonymous" : entity.Name,
            ParticipationDate = entity.ParticipationDate,
            Score = entity.Score
        };
    }
}