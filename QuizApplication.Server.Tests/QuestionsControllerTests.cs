using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using QuizApplication.DataAccess.Constants;
using QuizApplication.DataAccess.DTO;
using QuizApplication.DataAccess.Services.Contracts;
using QuizApplication.Server.Controllers;

namespace QuizApplication.Server.Tests;

public class QuestionTestingData
{
    protected readonly IEnumerable<QuestionReadOnlyDto> QuestionsDto = [
        new() { Type = QuestionType.Single, Title = "Test Question", Choises = ["A", "B", "C", "D"], CorrectOptions = ["A"], Points = 1 },
        new() { Type = QuestionType.Multiple, Title = "Test Question", Choises = ["A", "B", "C", "D"], CorrectOptions = ["A", "C"], Points = 1 },
        new() { Type = QuestionType.Single, Title = "Test Question", Choises = ["A", "B", "C", "D"], CorrectOptions = ["D"], Points = 1 },
        new() { Type = QuestionType.Typed, Title = "Test Question", Choises = [], CorrectOptions = ["Typed answer"], Points = 1 },
    ];

    protected readonly IEnumerable<QuestionReadOnlyDto> QuestionsDtoEmpty = [];
}

public class QuestionsControllerTests : QuestionTestingData
{
    [Fact]
    public async Task GetQuizQuestions_ReturnsOkResult_AllResults()
    {
        // Arrange
        var mockService = new Mock<IQuestionService>();
        mockService.Setup(service => service.GetQuestionsAsync()).ReturnsAsync(QuestionsDto);
        var controller = new QuestionsController(mockService.Object);

        // Act
        var result = await controller.GetQuestions();

        // Assert
        Assert.IsType<Ok<IEnumerable<QuestionReadOnlyDto>>>(result);
    }

    [Fact]
    public async Task GetQuizQuestions_ReturnsNoContent_EmptyList()
    {
        // Arrange
        var mockService = new Mock<IQuestionService>();
        mockService.Setup(service => service.GetQuestionsAsync()).ReturnsAsync(QuestionsDtoEmpty);
        var controller = new QuestionsController(mockService.Object);

        // Act
        var result = await controller.GetQuestions();

        // Assert
        Assert.IsType<NoContent>(result);
    }
}