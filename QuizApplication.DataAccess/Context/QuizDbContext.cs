using Microsoft.EntityFrameworkCore;
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
                Title = "Question 1",
                Choises = ["Option 1", "Option 2", "Option 3", "Option 4"],
                CorrectOptions = ["Option 2"],
                Points = 1
            },
            new Question()
            {
                Id = 2,
                Title = "Question 2",
                Choises = ["Option 1", "Option 2", "Option 3", "Option 4"],
                CorrectOptions = ["Option 1", "Option 3"],
                Points = 1
            },
            new Question()
            {
                Id = 3,
                Title = "Question 2",
                Choises = ["Option 1", "Option 2", "Option 3", "Option 4"],
                CorrectOptions = ["Option 4"],
                Points = 1
            }
        );
    }
}