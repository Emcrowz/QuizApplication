﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizApplication.DataAccess.Context;

#nullable disable

namespace QuizApplication.DataAccess.Migrations.Development
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20250115231956_InitialiseCleanDb")]
    partial class InitialiseCleanDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("QuizApplication.DataAccess.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ParticipationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("QuizApplication.DataAccess.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.PrimitiveCollection<string>("Choises")
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("CorrectOptions")
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Choises = "[\"Dark chocolate\",\"Canned tuna\",\"Honey\",\"Peanut butter\"]",
                            CorrectOptions = "[\"Honey\"]",
                            Points = 100,
                            Title = "What is the only food that cannot go bad?",
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 2,
                            Choises = "[\"Python\",\"HTML\",\"SQL\",\"Java\"]",
                            CorrectOptions = "[\"Python\",\"SQL\",\"Java\"]",
                            Points = 100,
                            Title = "Which of the following are programming languages?",
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 3,
                            Choises = "[\"Eiffel Tower\",\"Forbidden City\",\"Colosseum\",\"Statue of Liberty\"]",
                            CorrectOptions = "[\"Forbidden City\"]",
                            Points = 100,
                            Title = "Which of these is the most visited attraction in the world?",
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 4,
                            Choises = "[]",
                            CorrectOptions = "[\"Neutron\"]",
                            Points = 100,
                            Title = "What part of the atom has no electric charge?",
                            Type = (byte)0
                        },
                        new
                        {
                            Id = 5,
                            Choises = "[\"Sr\",\"Am\",\"Xe\",\"D\"]",
                            CorrectOptions = "[\"Sr\",\"Am\",\"Xe\"]",
                            Points = 100,
                            Title = "Which elements belong to the periodic table of the elements?",
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 6,
                            Choises = "[]",
                            CorrectOptions = "[\"Venus\"]",
                            Points = 100,
                            Title = "Which planet is the hottest in the solar system?",
                            Type = (byte)0
                        },
                        new
                        {
                            Id = 7,
                            Choises = "[\"Brain\",\"Liver\",\"Heart\",\"Skin\"]",
                            CorrectOptions = "[\"Skin\"]",
                            Points = 100,
                            Title = "What’s the heaviest organ in the human body?",
                            Type = (byte)1
                        },
                        new
                        {
                            Id = 8,
                            Choises = "[]",
                            CorrectOptions = "[\"K\"]",
                            Points = 100,
                            Title = "What is the symbol for potassium?",
                            Type = (byte)0
                        },
                        new
                        {
                            Id = 9,
                            Choises = "[\"byte\",\"bool\",\"decimal\",\"char\"]",
                            CorrectOptions = "[\"byte\",\"bool\",\"decimal\",\"char\"]",
                            Points = 100,
                            Title = "In C# which types are value types?",
                            Type = (byte)2
                        },
                        new
                        {
                            Id = 10,
                            Choises = "[\"var\",\"const\",\"ref\",\"let\"]",
                            CorrectOptions = "[\"var\",\"const\",\"let\"]",
                            Points = 100,
                            Title = "Which are correct ways to declare a variable in JavaScript?",
                            Type = (byte)2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
