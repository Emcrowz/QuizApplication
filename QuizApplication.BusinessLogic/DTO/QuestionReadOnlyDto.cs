﻿using QuizApplication.DataAccess.Constants;

namespace QuizApplication.BusinessLogic.DTO;

public record QuestionReadOnlyDto
{
    public int Id { get; init; }
    public QuestionType Type { get; init; }
    public string Title { get; init; }
    public IEnumerable<string>? Choises { get; init; }
    public IEnumerable<string>? CorrectOptions { get; init; }
    public int Points { get; init; }
}