﻿using QuizApplication.BusinessLogic.DTO;
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
            CorrectOptions = entity.CorrectOptions,
            Points = entity.Points
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
            Email = entity.Email,
            Name = entity.Email,
            ParticipationDate = entity.ParticipationDate,
            Score = entity.Score
        };
    }
}