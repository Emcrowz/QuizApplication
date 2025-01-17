﻿namespace QuizApplication.BusinessLogic.DTO;

public record ParticipantReadOnlyDto
{
    public string? Email { get; init; }
    public string? Name { get; init; }
    public int Score { get; init; }
    public DateTime ParticipationDate { get; init; }
}