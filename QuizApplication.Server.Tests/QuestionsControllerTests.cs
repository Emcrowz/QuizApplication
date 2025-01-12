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
    private readonly Mock<IQuestionService> _mockService;
    private readonly QuestionsController _controller;

    public QuestionsControllerTests()
    {
        _mockService = new Mock<IQuestionService>();
        _controller = new QuestionsController(_mockService.Object);
    }

    [Fact]
    public async Task GetQuizQuestions_ReturnsOkResult_WhenExists()
    {
        // Arrange
        _mockService.Setup(service => service.GetQuestionsAsync()).ReturnsAsync(QuestionsDto);

        // Act
        var result = await _controller.GetQuestions();

        // Assert
        Assert.IsType<Ok<IEnumerable<QuestionReadOnlyDto>>>(result);
    }

    [Fact]
    public async Task GetQuizQuestions_ReturnsNoContent_WhenEmpty()
    {
        // Arrange
        _mockService.Setup(service => service.GetQuestionsAsync()).ReturnsAsync(QuestionsDtoEmpty);

        // Act
        var result = await _controller.GetQuestions();

        // Assert
        Assert.IsType<NoContent>(result);
    }
}