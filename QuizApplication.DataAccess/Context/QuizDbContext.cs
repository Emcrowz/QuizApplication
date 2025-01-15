using Microsoft.EntityFrameworkCore;
using QuizApplication.DataAccess.Constants;
using QuizApplication.DataAccess.Models;

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
    }
}