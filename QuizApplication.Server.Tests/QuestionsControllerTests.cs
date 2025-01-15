using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.DataAccess.Constants;
using QuizApplication.Server.Controllers;

namespace QuizApplication.Server.Tests;

public class QuestionTestingData
{
    protected readonly IEnumerable<QuestionReadOnlyDto> QuestionsDto = new List<QuestionReadOnlyDto>
    {
        new() { Id = 1, Type = QuestionType.Single, Title = "Test Question", Choises = new List<string> { "A", "B", "C", "D" }, CorrectOptions = new List<string> { "A" }, Points = 1 },
        new() { Id = 2, Type = QuestionType.Multiple, Title = "Test Question", Choises = new List<string> { "A", "B", "C", "D" }, CorrectOptions = new List<string> { "A", "C" }, Points = 1 },
        new() { Id = 3, Type = QuestionType.Single, Title = "Test Question", Choises = new List<string> { "A", "B", "C", "D" }, CorrectOptions = new List<string> { "D" }, Points = 1 },
        new() { Id = 4, Type = QuestionType.Typed, Title = "Test Question", Choises = new List<string>(), CorrectOptions = new List<string> { "Typed answer" }, Points = 1 },
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