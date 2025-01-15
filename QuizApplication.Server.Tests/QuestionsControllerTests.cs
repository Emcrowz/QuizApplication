using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.DataAccess.Constants;
using QuizApplication.Server.Controllers;

namespace QuizApplication.Server.Tests;

public class QuestionTestingData
{
    protected readonly QuestionReadOnlyDto QuestionDto = new()
    {
        Type = QuestionType.Multiple,
        Title = "Test Question",
        Choises = new List<string> { "A", "B", "C", "D" },
    };

    protected readonly IEnumerable<QuestionReadOnlyDto> QuestionsDto = new List<QuestionReadOnlyDto>
    {
        new() { Type = QuestionType.Single, Title = "Test Question 1", Choises = new List<string> { "A", "B", "C", "D" } },
        new() { Type = QuestionType.Multiple, Title = "Test Question 2", Choises = new List<string> { "A", "B", "C", "D" } },
        new() { Type = QuestionType.Single, Title = "Test Question 3", Choises = new List<string> { "A", "B", "C", "D" } },
        new() { Type = QuestionType.Typed, Title = "Test Question 4", Choises = new List<string>() },
        new() { Type = QuestionType.Single, Title = "Test Question 5", Choises = new List<string> { "A", "B", "C", "D" }},
        new() { Type = QuestionType.Multiple, Title = "Test Question 6", Choises = new List<string> { "A", "B", "C", "D" } },
        new() { Type = QuestionType.Single, Title = "Test Question 7", Choises = new List<string> { "A", "B", "C", "D" } },
        new() { Type = QuestionType.Typed, Title = "Test Question 8", Choises = new List<string>() },
        new() { Type = QuestionType.Single, Title = "Test Question 9", Choises = new List<string> { "A", "B", "C", "D" } },
        new() { Type = QuestionType.Multiple, Title = "Test Question 10", Choises = new List<string> { "A", "B", "C", "D" } },
        new() { Type = QuestionType.Single, Title = "Test Question 11", Choises = new List<string> { "A", "B", "C", "D" } },
        new() { Type = QuestionType.Typed, Title = "Test Question 12", Choises = new List<string>() },
    };

    protected readonly IEnumerable<QuestionReadOnlyDto> QuestionsDtoEmpty = new List<QuestionReadOnlyDto>();
}

public class QuestionsControllerTests : QuestionTestingData
{
    private readonly Mock<IQuestionsService> _mockService;
    private readonly QuestionsController _controller;

    public QuestionsControllerTests()
    {
        _mockService = new Mock<IQuestionsService>();
        _controller = new QuestionsController(_mockService.Object);
    }

    [Fact]
    public async Task GetQuizQuestions_ReturnsOkResult_WhenExists()
    {
        // Arrange
        _mockService.Setup(service => service.GetQuestionsAsync()).ReturnsAsync(QuestionsDto);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsType<Ok<IEnumerable<QuestionReadOnlyDto>>>(result);
    }

    [Fact]
    public async Task GetQuizQuestions_ReturnsNoContent_WhenEmpty()
    {
        // Arrange
        _mockService.Setup(service => service.GetQuestionsAsync()).ReturnsAsync(QuestionsDtoEmpty);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsType<NoContent>(result);
    }

    [Fact]
    public async Task GetQuizQuestions_ReturnsProblem_OnException()
    {
        // Arrange
        _mockService.Setup(service => service.GetQuestionsAsync()).ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsType<ProblemHttpResult>(result);
    }
}