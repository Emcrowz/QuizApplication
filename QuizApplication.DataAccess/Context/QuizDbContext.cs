using Microsoft.EntityFrameworkCore;
using QuizApplication.DataAccess.Models;
using System.Globalization;

namespace QuizApplication.DataAccess.Context;

public class QuizDbContext(DbContextOptions<QuizDbContext> options) : DbContext(options)
{
    public DbSet<Question> Questions { get; init; }
    public DbSet<Participant> Participants { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>().HasData(
            new Question()
            {
                Id = 1,
                Type = QuestionType.Single,
                Title = "Question 1",
                Choises = ["Option 1", "Option 2", "Option 3", "Option 4"],
                CorrectOptions = ["Option 2"],
                Points = 1
            },
            new Question()
            {
                Id = 2,
                Type = QuestionType.Multiple,
                Title = "Question 2",
                Choises = ["Option 1", "Option 2", "Option 3", "Option 4"],
                CorrectOptions = ["Option 1", "Option 3"],
                Points = 1
            },
            new Question()
            {
                Id = 3,
                Type = QuestionType.Single,
                Title = "Question 3",
                Choises = ["Option 1", "Option 2", "Option 3", "Option 4"],
                CorrectOptions = ["Option 4"],
                Points = 1
            },
            new Question()
            {
                Id = 4,
                Type = QuestionType.Typed,
                Title = "Question 4",
                Choises = [],
                CorrectOptions = ["Written Answer"],
                Points = 1
            },
            new Question()
            {
                Id = 5,
                Type = QuestionType.Multiple,
                Title = "Question 5",
                Choises = ["Option 1", "Option 2", "Option 3", "Option 4"],
                CorrectOptions = ["Option 1", "Option 2", "Option 4"],
                Points = 1
            },
            new Question()
            {
                Id = 6,
                Type = QuestionType.Typed,
                Title = "Question 6",
                Choises = [],
                CorrectOptions = ["Another Custom"],
                Points = 1
            },
            new Question()
            {
                Id = 7,
                Type = QuestionType.Single,
                Title = "Question 7",
                Choises = ["Option 1", "Option 2", "Option 3", "Option 4"],
                CorrectOptions = ["Option 4"],
                Points = 1
            },
            new Question()
            {
                Id = 8,
                Type = QuestionType.Typed,
                Title = "Question 8",
                Choises = [],
                CorrectOptions = ["Custom"],
                Points = 1
            },
            new Question()
            {
                Id = 9,
                Type = QuestionType.Multiple,
                Title = "Question 9",
                Choises = ["Option 1", "Option 2", "Option 3", "Option 4"],
                CorrectOptions = ["Option 2", "Option 3"],
                Points = 1
            },
            new Question()
            {
                Id = 10,
                Type = QuestionType.Multiple,
                Title = "Question 10",
                Choises = ["Option 1", "Option 2", "Option 3", "Option 4"],
                CorrectOptions = ["Option 1", "Option 4"],
                Points = 1
            }
        );

        modelBuilder.Entity<Participant>().HasData(
            new Participant() { Id = 1, Email = "Jane.Doe@mail.com", Name = "Jane Doe", ParticipationDate = DateTime.Parse("2023-01-11", CultureInfo.InvariantCulture), Score = 2 },
            new Participant() { Id = 2, Email = "John.Doe@mail.com", Name = "John Doe", ParticipationDate = DateTime.Parse("2024-02-16", CultureInfo.InvariantCulture), Score = 10 },
            new Participant() { Id = 3, Email = "Jane.Doe@mail.com", Name = "Jane Doe", ParticipationDate = DateTime.Parse("2021-05-12", CultureInfo.InvariantCulture), Score = 8 },
            new Participant() { Id = 4, Email = "John.Doe@mail.com", Name = "John Doe", ParticipationDate = DateTime.Parse("2022-02-08", CultureInfo.InvariantCulture), Score = 7 },
            new Participant() { Id = 5, Email = "Jane.Doe@mail.com", Name = "Jane Doe", ParticipationDate = DateTime.Parse("2022-06-09", CultureInfo.InvariantCulture), Score = 4 },
            new Participant() { Id = 6, Email = "Jane.Doe@mail.com", Name = "Jane Doe", ParticipationDate = DateTime.Parse("2022-09-17", CultureInfo.InvariantCulture), Score = 0 },
            new Participant() { Id = 7, Email = "Jane.Doe@mail.com", Name = "Jane Doe", ParticipationDate = DateTime.Parse("2022-11-23", CultureInfo.InvariantCulture), Score = 1 },
            new Participant() { Id = 8, Email = "Jane.Doe@mail.com", Name = "Jane Doe", ParticipationDate = DateTime.Parse("2021-12-21", CultureInfo.InvariantCulture), Score = 1 },
            new Participant() { Id = 9, Email = "Jane.Doe@mail.com", Name = "Jane Doe", ParticipationDate = DateTime.Parse("2021-11-10", CultureInfo.InvariantCulture), Score = 0 },
            new Participant() { Id = 10, Email = "Jane.Doe@mail.com", Name = "Jane Doe", ParticipationDate = DateTime.Parse("2021-09-03", CultureInfo.InvariantCulture), Score = 8 },
            new Participant() { Id = 11, Email = "Jane.Doe@mail.com", Name = "Jane Doe", ParticipationDate = DateTime.Parse("2024-05-06", CultureInfo.InvariantCulture), Score = 3 },
            new Participant() { Id = 12, Email = "Jane.Doe@mail.com", Name = "Jane Doe", ParticipationDate = DateTime.Parse("2023-04-02", CultureInfo.InvariantCulture), Score = 0 }
        );
    }
}