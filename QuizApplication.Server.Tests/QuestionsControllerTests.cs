using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.DataAccess.Constants;
using QuizApplication.Server.Controllers;

namespace QuizApplication.Server.Tests;

public class QuestionTestingData
{
    protected readonly IEnumerable<QuestionReadOnlyDto> QuestionsDto = [
        new() { Id = 1, Type = QuestionType.Single, Title = "Test Question", Choises = ["A", "B", "C", "D"], CorrectOptions = ["A"], Points = 1 },
        new() { Id = 2, Type = QuestionType.Multiple, Title = "Test Question", Choises = ["A", "B", "C", "D"], CorrectOptions = ["A", "C"], Points = 1 },
        new() { Id = 3, Type = QuestionType.Single, Title = "Test Question", Choises = ["A", "B", "C", "D"], CorrectOptions = ["D"], Points = 1 },
        new() { Id = 4, Type = QuestionType.Typed, Title = "Test Question", Choises = [], CorrectOptions = ["Typed answer"], Points = 1 },
    ];

    protected readonly IEnumerable<QuestionReadOnlyDto> QuestionsDtoEmpty = [];
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