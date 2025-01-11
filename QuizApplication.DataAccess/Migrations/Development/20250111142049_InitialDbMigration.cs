using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuizApplication.DataAccess.Migrations.Development
{
    /// <inheritdoc />
    public partial class InitialDbMigration : Migration
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
                table: "Participants",
                columns: new[] { "Id", "Email", "Name", "ParticipationDate", "Score" },
                values: new object[,]
                {
                    { 1, "Jane.Doe@mail.com", "Jane Doe", new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, "John.Doe@mail.com", "John Doe", new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 3, "Jane.Doe@mail.com", "Jane Doe", new DateTime(2021, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 4, "John.Doe@mail.com", "John Doe", new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 5, "Jane.Doe@mail.com", "Jane Doe", new DateTime(2022, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 6, "Jane.Doe@mail.com", "Jane Doe", new DateTime(2022, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 7, "Jane.Doe@mail.com", "Jane Doe", new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, "Jane.Doe@mail.com", "Jane Doe", new DateTime(2021, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, "Jane.Doe@mail.com", "Jane Doe", new DateTime(2021, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 10, "Jane.Doe@mail.com", "Jane Doe", new DateTime(2021, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 11, "Jane.Doe@mail.com", "Jane Doe", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, "Jane.Doe@mail.com", "Jane Doe", new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Choises", "CorrectOptions", "Points", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "[\"Option 1\",\"Option 2\",\"Option 3\",\"Option 4\"]", "[\"Option 2\"]", 1, "Question 1", (byte)1 },
                    { 2, "[\"Option 1\",\"Option 2\",\"Option 3\",\"Option 4\"]", "[\"Option 1\",\"Option 3\"]", 1, "Question 2", (byte)2 },
                    { 3, "[\"Option 1\",\"Option 2\",\"Option 3\",\"Option 4\"]", "[\"Option 4\"]", 1, "Question 3", (byte)1 },
                    { 4, "[]", "[\"Written Answer\"]", 1, "Question 4", (byte)0 },
                    { 5, "[\"Option 1\",\"Option 2\",\"Option 3\",\"Option 4\"]", "[\"Option 1\",\"Option 2\",\"Option 4\"]", 1, "Question 5", (byte)2 },
                    { 6, "[]", "[\"Another Custom\"]", 1, "Question 6", (byte)0 },
                    { 7, "[\"Option 1\",\"Option 2\",\"Option 3\",\"Option 4\"]", "[\"Option 4\"]", 1, "Question 7", (byte)1 },
                    { 8, "[]", "[\"Custom\"]", 1, "Question 8", (byte)0 },
                    { 9, "[\"Option 1\",\"Option 2\",\"Option 3\",\"Option 4\"]", "[\"Option 2\",\"Option 3\"]", 1, "Question 9", (byte)2 },
                    { 10, "[\"Option 1\",\"Option 2\",\"Option 3\",\"Option 4\"]", "[\"Option 1\",\"Option 4\"]", 1, "Question 10", (byte)2 }
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
