using Microsoft.EntityFrameworkCore;
using QuizApplication.DataAccess.Constants;
using QuizApplication.DataAccess.Models;

namespace QuizApplication.DataAccess.Context;

public sealed class QuizDbContext(DbContextOptions<QuizDbContext> context) : DbContext(context)
{
    public DbSet<Question> Questions { get; set; }
    public DbSet<Participant> Participants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>().HasData(
            new Question()
            {
                Id = 1,
                Type = QuestionType.Single,
                Title = "What is the only food that cannot go bad?",
                Choises = ["Dark chocolate", "Canned tuna", "Honey", "Peanut butter"],
                CorrectOptions = ["Honey"],
                Points = 100
            },
            new Question()
            {
                Id = 2,
                Type = QuestionType.Multiple,
                Title = "Which of the following are programming languages?",
                Choises = ["Python", "HTML", "SQL", "Java"],
                CorrectOptions = ["Python", "SQL", "Java"],
                Points = 100
            },
            new Question()
            {
                Id = 3,
                Type = QuestionType.Single,
                Title = "Which of these is the most visited attraction in the world?",
                Choises = ["Eiffel Tower", "Forbidden City", "Colosseum", "Statue of Liberty"],
                CorrectOptions = ["Forbidden City"],
                Points = 100
            },
            new Question()
            {
                Id = 4,
                Type = QuestionType.Typed,
                Title = "What part of the atom has no electric charge?",
                Choises = [],
                CorrectOptions = ["Neutron"],
                Points = 100
            },
            new Question()
            {
                Id = 5,
                Type = QuestionType.Multiple,
                Title = "Which elements belong to the periodic table of the elements?",
                Choises = ["Sr", "Am", "Xe", "D"],
                CorrectOptions = ["Sr", "Am", "Xe"],
                Points = 100
            },
            new Question()
            {
                Id = 6,
                Type = QuestionType.Typed,
                Title = "Which planet is the hottest in the solar system?",
                Choises = [],
                CorrectOptions = ["Venus"],
                Points = 100
            },
            new Question()
            {
                Id = 7,
                Type = QuestionType.Single,
                Title = "What’s the heaviest organ in the human body?",
                Choises = ["Brain", "Liver", "Heart", "Skin"],
                CorrectOptions = ["Skin"],
                Points = 100
            },
            new Question()
            {
                Id = 8,
                Type = QuestionType.Typed,
                Title = "What is the symbol for potassium?",
                Choises = [],
                CorrectOptions = ["K"],
                Points = 100
            },
            new Question()
            {
                Id = 9,
                Type = QuestionType.Multiple,
                Title = "In C# which types are value types?",
                Choises = ["byte", "bool", "decimal", "char"],
                CorrectOptions = ["byte", "bool", "decimal", "char"],
                Points = 100
            },
            new Question()
            {
                Id = 10,
                Type = QuestionType.Multiple,
                Title = "Which are correct ways to declare a variable in JavaScript?",
                Choises = ["var", "const", "ref", "let"],
                CorrectOptions = ["var", "const", "let"],
                Points = 100
            }
        );

        modelBuilder.Entity<Participant>().HasData(
            new Participant() {
                Id = 1,
                Name = "Person",
                Email = "person@mail.com",
                ParticipationDate = DateTime.Parse("2024-03-01"),
                Score = 400
            },
            new Participant() {
                Id = 2,
                Name = "Someone",
                Email = "some@one.com",
                ParticipationDate = DateTime.Parse("2024-03-01"),
                Score = 633
            },
            new Participant() {
                Id = 3,
                Name = "John Doe",
                Email = "john.doe@example.com",
                ParticipationDate = DateTime.Parse("2024-03-02"),
                Score = 500
            },
            new Participant() {
                Id = 4,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                ParticipationDate = DateTime.Parse("2024-03-03"),
                Score = 450
            },
            new Participant() {
                Id = 5,
                Name = "Alice Johnson",
                Email = "alice.johnson@example.com",
                ParticipationDate = DateTime.Parse("2024-03-04"),
                Score = 550
            },
            new Participant() {
                Id = 6,
                Name = "Bob Brown",
                Email = "bob.brown@example.com",
                ParticipationDate = DateTime.Parse("2024-03-05"),
                Score = 600
            },
            new Participant() {
                Id = 7,
                Name = "Charlie Davis",
                Email = "charlie.davis@example.com",
                ParticipationDate = DateTime.Parse("2024-03-06"),
                Score = 620
            },
            new Participant() {
                Id = 8,
                Name = "Diana Evans",
                Email = "diana.evans@example.com",
                ParticipationDate = DateTime.Parse("2024-03-07"),
                Score = 480
            },
            new Participant() {
                Id = 9,
                Name = "Ethan Harris",
                Email = "ethan.harris@example.com",
                ParticipationDate = DateTime.Parse("2024-03-08"),
                Score = 530
            },
            new Participant() {
                Id = 10,
                Name = "Fiona Clark",
                Email = "fiona.clark@example.com",
                ParticipationDate = DateTime.Parse("2024-03-09"),
                Score = 470
            },
            new Participant() {
                Id = 11,
                Name = "George Lewis",
                Email = "george.lewis@example.com",
                ParticipationDate = DateTime.Parse("2024-03-10"),
                Score = 490
            },
            new Participant() {
                Id = 12,
                Name = "Hannah Walker",
                Email = "hannah.walker@example.com",
                ParticipationDate = DateTime.Parse("2024-03-11"),
                Score = 510
            },
            new Participant() {
                Id = 13,
                Name = "Ian Young",
                Email = "ian.young@example.com",
                ParticipationDate = DateTime.Parse("2024-03-12"),
                Score = 580
            },
            new Participant() {
                Id = 14,
                Name = "Jessica King",
                Email = "jessica.king@example.com",
                ParticipationDate = DateTime.Parse("2024-03-13"),
                Score = 560
            },
            new Participant() {
                Id = 15,
                Name = "Kevin Scott",
                Email = "kevin.scott@example.com",
                ParticipationDate = DateTime.Parse("2024-03-14"),
                Score = 540
            },
            new Participant() {
                Id = 16,
                Name = "Laura Martinez",
                Email = "laura.martinez@example.com",
                ParticipationDate = DateTime.Parse("2024-03-15"),
                Score = 590
            }
        );
    }
}