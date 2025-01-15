﻿using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Helpers;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.DataAccess.Constants;
using QuizApplication.DataAccess.Context;
using QuizApplication.DataAccess.Models;
using QuizApplication.DataAccess.Repositories;
using QuizApplication.DataAccess.Repositories.Contracts;

namespace QuizApplication.BusinessLogic.Services;

public class ParticipantsService(QuizDbContext context) : IParticipantsService
{
    private readonly IParticipantRepository _participantRepository = new ParticipantRepository(context);
    private readonly IQuestionRepository _questionRepository = new QuestionRepository(context);

    public async Task<IEnumerable<ParticipantReadOnlyDto>> GetParticipantsAsync()
    {
        var data = await _participantRepository.GetAllAsync();

        List<ParticipantReadOnlyDto> dtos = [];
        foreach (Participant participant in data)
        {
            dtos.Add(ModelConverter.ConvertParticipantToReadOnlyDTO<ParticipantReadOnlyDto>(participant));
        }

        return dtos;
    }

    public async Task<IEnumerable<ParticipantReadOnlyDto>> GetTop10ParticipantsForLeaderboardAsync()
    {
        var data = await _participantRepository.GetAllAsync();

        List<ParticipantReadOnlyDto> dtos = [];
        foreach (Participant participant in data)
        {
            dtos.Add(ModelConverter.ConvertParticipantToReadOnlyDTO<ParticipantReadOnlyDto>(participant));
        }

        return dtos.OrderByDescending(o => o.Score).Take(10);
    }

    public async Task<int> PostParticipantAsync(ParticipantPostDto entity)
    {
        var data = ModelConverter.ConvertParticipantPostDtoToModel<Participant>(entity);
        data.Score = await CalculateParticipantScore(entity.FinalAnswers!);

        var res = await _participantRepository.AddAsync(data);
        return res.Score;
    }

    private async Task<int> CalculateParticipantScore(string[][] answers)
    {
        IEnumerable<Question> questions = await _questionRepository.GetAllAsync();
        List<Question> questionBank = questions.ToList();
        int questionsInTotal = questionBank.Count;
        int finalResult = 0;

        for (int i = 0; i < questionsInTotal; i++)
        {
            string[] questionAnswer = answers[i];
            string[] correctOptions = questionBank[i].CorrectOptions!.Select(opt => opt.ToLower()).ToArray();

            if (questionBank[i].Type == QuestionType.Multiple)
            {
                int correctSelections = questionAnswer.Count(answer => correctOptions.Contains(answer.ToLower()));
                finalResult += (questionBank[i].Points / correctOptions.Length) * correctSelections;

                if (questionAnswer.Length > correctOptions.Length)
                {
                    int diff = questionAnswer.Length - correctOptions.Length;
                    finalResult -= (questionBank[i].Points / correctOptions.Length) * diff;
                }
            }
            else if (questionAnswer.All(answer => correctOptions.Contains(answer.ToLower())))
            {
                finalResult += questionBank[i].Points;
            }
        }

        return finalResult;
    }
}