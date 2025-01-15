using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.Server.Controllers;
using System.Globalization;

namespace QuizApplication.Server.Tests;

public class ParticipantTestingData
{
    protected readonly IEnumerable<ParticipantReadOnlyDto> ParticipantsDto = new List<ParticipantReadOnlyDto>
    {
        new() { Email = "a.b@mail.com", Name = "Test", ParticipationDate = DateTime.Parse("2023-01-12", CultureInfo.InvariantCulture), Score = 500 },
        new() { Email = "test.mail@mail.com", Name = "Test", ParticipationDate = DateTime.Parse("2021-11-04", CultureInfo.InvariantCulture), Score = 100 },
        new() { Email = "hello.world@mail.com", Name = "Test", ParticipationDate = DateTime.Parse("2024-03-20", CultureInfo.InvariantCulture), Score = 0 },
        new() { Email = "one@mail.com", Name = "Test", ParticipationDate = DateTime.Parse("2022-07-16", CultureInfo.InvariantCulture), Score = 300 },
    };

    protected readonly IEnumerable<ParticipantReadOnlyDto> ParticipantsDtoEmpty = new List<ParticipantReadOnlyDto>();

    protected readonly ParticipantPostDto ParticipantPostDto = new() { Email = "Test.Doe@mail.com", Name = "Test", ParticipationDate = DateTime.Now, FinalAnswers = new string[][] { }, Score = 500 };
}

public class ParticipantsControllerTests : ParticipantTestingData
{
    private readonly Mock<IParticipantsService> _mockService;
    private readonly ParticipantsController _controller;

    public ParticipantsControllerTests()
    {
        _mockService = new Mock<IParticipantsService>();
        _controller = new ParticipantsController(_mockService.Object);
    }

    [Fact]
    public async Task GetQuizParticipants_ReturnsOkResult_WhenExists()
    {
        // Arrange
        _mockService.Setup(service => service.GetParticipantsAsync()).ReturnsAsync(ParticipantsDto);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsType<Ok<IEnumerable<ParticipantReadOnlyDto>>>(result);
    }

    [Fact]
    public async Task GetQuizParticipants_ReturnsNoContent_WhenEmpty()
    {
        // Arrange
        _mockService.Setup(service => service.GetParticipantsAsync()).ReturnsAsync(ParticipantsDtoEmpty);

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsType<NoContent>(result);
    }

    [Fact]
    public async Task GetQuizParticipants_ReturnsProblem_OnException()
    {
        // Arrange
        _mockService.Setup(service => service.GetParticipantsAsync()).ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsType<ProblemHttpResult>(result);
    }

    [Fact]
    public async Task GetTop10Participants_ReturnsOkResult_WhenExists()
    {
        // Arrange
        _mockService.Setup(service => service.GetTop10ParticipantsForLeaderboardAsync()).ReturnsAsync(ParticipantsDto);

        // Act
        var result = await _controller.GetTop();

        // Assert
        Assert.IsType<Ok<IEnumerable<ParticipantReadOnlyDto>>>(result);
    }

    [Fact]
    public async Task GetTop10Participants_ReturnsNoContent_WhenEmpty()
    {
        // Arrange
        _mockService.Setup(service => service.GetTop10ParticipantsForLeaderboardAsync()).ReturnsAsync(ParticipantsDtoEmpty);

        // Act
        var result = await _controller.GetTop();

        // Assert
        Assert.IsType<NoContent>(result);
    }

    [Fact]
    public async Task GetTop10Participants_ReturnsProblem_OnException()
    {
        // Arrange
        _mockService.Setup(service => service.GetTop10ParticipantsForLeaderboardAsync()).ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _controller.GetTop();

        // Assert
        Assert.IsType<ProblemHttpResult>(result);
    }

    [Fact]
    public async Task PostParticipant_ReturnsScore()
    {
        // Arrange
        _mockService.Setup(service => service.PostParticipantAsync(ParticipantPostDto)).ReturnsAsync(1);

        // Act
        var result = await _controller.PostSingle(ParticipantPostDto);

        // Assert
        Assert.IsType<int>(ParticipantPostDto.Score);
        _mockService.Verify(service => service.PostParticipantAsync(ParticipantPostDto), Times.Once);
    }

    [Fact]
    public async Task PostParticipant_ReturnsBadRequest_OnInvalidModel()
    {
        // Arrange
        var invalidParticipantPostDto = new ParticipantPostDto { Email = "", Name = "", ParticipationDate = DateTime.Now, FinalAnswers = new string[][] { }, Score = 5 };

        // Act
        var result = await _controller.PostSingle(invalidParticipantPostDto);

        // Assert
        Assert.IsType<BadRequest>(result);
    }

    [Fact]
    public async Task PostParticipant_ReturnsProblem_OnException()
    {
        // Arrange
        _mockService.Setup(service => service.PostParticipantAsync(ParticipantPostDto)).ThrowsAsync(new Exception("Test exception"));

        // Act
        var result = await _controller.PostSingle(ParticipantPostDto);

        // Assert
        Assert.IsType<ProblemHttpResult>(result);
    }
}