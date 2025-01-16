using QuizApplication.BusinessLogic.DTO;
using QuizApplication.BusinessLogic.Helpers;
using QuizApplication.DataAccess.Constants;
using QuizApplication.DataAccess.Models;

namespace QuizApplication.BusinessLogic.Tests;

public class ModelConverterTest
{
    [Fact]
    public void ConvertQuestionToReadOnlyDTO_ShouldConvertCorrectly()
    {
        // Arrange
        var question = new Question
        {
            Type = QuestionType.Single,
            Title = "Sample Question",
            Choises = new List<string> { "Option1", "Option2" },
            CorrectOptions = new List<string> { "Option1" },
            Points = 10
        };

        // Act
        var result = ModelConverter.ConvertQuestionToReadOnlyDTO(question);

        // Assert
        Assert.Equal(question.Type, result.Type);
        Assert.Equal(question.Title, result.Title);
        Assert.Equal(question.Choises, result.Choises);
    }

    [Fact]
    public void ConvertParticipantToReadOnlyDTO_ShouldConvertCorrectly()
    {
        // Arrange
        var participant = new Participant
        {
            Email = "test@example.com",
            Name = "Test User",
            ParticipationDate = DateTime.Now,
            Score = 100
        };

        // Act
        var result = ModelConverter.ConvertParticipantToReadOnlyDTO(participant);

        // Assert
        Assert.Equal(participant.Email, result.Email);
        Assert.Equal(participant.Name, result.Name);
        Assert.Equal(participant.ParticipationDate, result.ParticipationDate);
        Assert.Equal(participant.Score, result.Score);
    }

    [Fact]
    public void ConvertParticipantPostDtoToModel_ShouldConvertCorrectly()
    {
        // Arrange
        var participantPostDto = new ParticipantPostDto
        {
            Email = "test@example.com",
            Name = "Test User",
            ParticipationDate = DateTime.Now,
            Score = 100
        };

        // Act
        var result = ModelConverter.ConvertParticipantPostDtoToModel(participantPostDto);

        // Assert
        Assert.Equal(0, result.Id);
        Assert.Equal(participantPostDto.Email, result.Email);
        Assert.Equal(participantPostDto.Name, result.Name);
        Assert.Equal(participantPostDto.ParticipationDate, result.ParticipationDate);
        Assert.Equal(participantPostDto.Score, result.Score);
    }
}
