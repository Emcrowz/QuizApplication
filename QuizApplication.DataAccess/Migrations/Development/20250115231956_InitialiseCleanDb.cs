using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApplication.DataAccess.Migrations.Development
{
    /// <inheritdoc />
    public partial class InitialiseCleanDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    ParticipationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<byte>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Choises = table.Column<string>(type: "TEXT", nullable: true),
                    CorrectOptions = table.Column<string>(type: "TEXT", nullable: true),
                    Points = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Choises", "CorrectOptions", "Points", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "[\"Dark chocolate\",\"Canned tuna\",\"Honey\",\"Peanut butter\"]", "[\"Honey\"]", 100, "What is the only food that cannot go bad?", (byte)1 },
                    { 2, "[\"Python\",\"HTML\",\"SQL\",\"Java\"]", "[\"Python\",\"SQL\",\"Java\"]", 100, "Which of the following are programming languages?", (byte)2 },
                    { 3, "[\"Eiffel Tower\",\"Forbidden City\",\"Colosseum\",\"Statue of Liberty\"]", "[\"Forbidden City\"]", 100, "Which of these is the most visited attraction in the world?", (byte)1 },
                    { 4, "[]", "[\"Neutron\"]", 100, "What part of the atom has no electric charge?", (byte)0 },
                    { 5, "[\"Sr\",\"Am\",\"Xe\",\"D\"]", "[\"Sr\",\"Am\",\"Xe\"]", 100, "Which elements belong to the periodic table of the elements?", (byte)2 },
                    { 6, "[]", "[\"Venus\"]", 100, "Which planet is the hottest in the solar system?", (byte)0 },
                    { 7, "[\"Brain\",\"Liver\",\"Heart\",\"Skin\"]", "[\"Skin\"]", 100, "What’s the heaviest organ in the human body?", (byte)1 },
                    { 8, "[]", "[\"K\"]", 100, "What is the symbol for potassium?", (byte)0 },
                    { 9, "[\"byte\",\"bool\",\"decimal\",\"char\"]", "[\"byte\",\"bool\",\"decimal\",\"char\"]", 100, "In C# which types are value types?", (byte)2 },
                    { 10, "[\"var\",\"const\",\"ref\",\"let\"]", "[\"var\",\"const\",\"let\"]", 100, "Which are correct ways to declare a variable in JavaScript?", (byte)2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
