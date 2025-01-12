using Microsoft.AspNetCore.Http.HttpResults;
using Moq;
using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Services.Contracts;
using QuizApplication.Server.Controllers;
using System.Globalization;

namespace QuizApplication.Server.Tests;

public class ParticipantTestingData
{
    protected readonly IEnumerable<ParticipantReadOnlyDto> ParticipantsDto = [
        new() { Email = "a.b@mail.com", Name = "Test", ParticipationDate = DateTime.Parse("2023-01-12", CultureInfo.InvariantCulture), Score = 5 },
        new() { Email = "test.mail@mail.com", Name = "Test", ParticipationDate = DateTime.Parse("2021-11-04", CultureInfo.InvariantCulture), Score = 10 },
        new() { Email = "hello.world@mail.com", Name = "Test", ParticipationDate = DateTime.Parse("2024-03-20", CultureInfo.InvariantCulture), Score = 0 },
        new() { Email = "one@mail.com", Name = "Test", ParticipationDate = DateTime.Parse("2022-07-16", CultureInfo.InvariantCulture), Score = 3 },
    ];

    protected readonly IEnumerable<ParticipantReadOnlyDto> ParticipantsDtoEmpty = [];

    protected readonly ParticipantPostDto ParticipantPostDto = new() { Email = "Test.Doe@mail.com", Name = "Test", ParticipationDate = DateTime.Now, Score = 5 };
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
        var result = await _controller.GetParticipants();

        // Assert
        Assert.IsType<Ok<IEnumerable<ParticipantReadOnlyDto>>>(result);
    }

    [Fact]
    public async Task GetQuizParticipants_ReturnsNoContent_WhenEmpty()
    {
        // Arrange
        _mockService.Setup(service => service.GetParticipantsAsync()).ReturnsAsync(ParticipantsDtoEmpty);

        // Act
        var result = await _controller.GetParticipants();

        // Assert
        Assert.IsType<NoContent>(result);
    }

    [Fact]
    public async Task PostParticipant_ReturnsOkResult()
    {
        // Arrange && Act
        var result = await _controller.PostParticipant(ParticipantPostDto);

        // Assert
        Assert.IsType<Ok>(result);
        _mockService.Verify(service => service.PostParticipantAsync(ParticipantPostDto), Times.Once);
    }
}