﻿// <auto-generated />
using System;
using Harmony.Fitness.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Harmony.Fitness.Data.Migrations
{
    [DbContext(typeof(FitnessDbContext))]
    [Migration("20230602160949_UpdateExerciseColumns")]
    partial class UpdateExerciseColumns
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Harmony.Fitness.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("Harmony.Fitness.Models.ExerciseProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("ExerciseDetails");
                });

            modelBuilder.Entity("Harmony.Fitness.Models.ExerciseSuggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExerciseSuggestions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Plank"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lat pull down"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hip thrust"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Glute kickbacks"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Side leg lifts"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Lunges"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Reverse lunges"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Warm up"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Stretching"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Shoulder press"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Squats"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Bicep curls"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Hip"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Plank hip dips"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Treadmil"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Lat raise"
                        },
                        new
                        {
                            Id = 17,
                            Name = "DB chest press"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Knee push up"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Dead bugs"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Steps"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Russian Twist"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Single leg deadlift"
                        });
                });

            modelBuilder.Entity("Harmony.Fitness.Models.ExerciseSuggestionUnit", b =>
                {
                    b.Property<int>("ExerciseSuggestionId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseSuggestionId", "UnitId");

                    b.HasIndex("UnitId");

                    b.ToTable("ExerciseSuggestionUnit");

                    b.HasData(
                        new
                        {
                            ExerciseSuggestionId = 1,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 1,
                            UnitId = 4
                        },
                        new
                        {
                            ExerciseSuggestionId = 1,
                            UnitId = 5
                        },
                        new
                        {
                            ExerciseSuggestionId = 2,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 2,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 2,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 3,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 3,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 3,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 4,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 4,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 4,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 5,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 5,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 5,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 6,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 6,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 6,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 7,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 7,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 7,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 8,
                            UnitId = 4
                        },
                        new
                        {
                            ExerciseSuggestionId = 9,
                            UnitId = 4
                        },
                        new
                        {
                            ExerciseSuggestionId = 10,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 10,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 10,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 11,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 11,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 11,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 12,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 12,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 12,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 13,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 13,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 13,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 14,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 14,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 14,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 15,
                            UnitId = 3
                        },
                        new
                        {
                            ExerciseSuggestionId = 15,
                            UnitId = 4
                        },
                        new
                        {
                            ExerciseSuggestionId = 15,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 15,
                            UnitId = 8
                        },
                        new
                        {
                            ExerciseSuggestionId = 15,
                            UnitId = 9
                        },
                        new
                        {
                            ExerciseSuggestionId = 16,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 16,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 16,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 17,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 17,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 17,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 18,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 18,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 18,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 19,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 19,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 19,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 20,
                            UnitId = 10
                        },
                        new
                        {
                            ExerciseSuggestionId = 21,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 21,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 21,
                            UnitId = 6
                        },
                        new
                        {
                            ExerciseSuggestionId = 22,
                            UnitId = 1
                        },
                        new
                        {
                            ExerciseSuggestionId = 22,
                            UnitId = 2
                        },
                        new
                        {
                            ExerciseSuggestionId = 22,
                            UnitId = 6
                        });
                });

            modelBuilder.Entity("Harmony.Fitness.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Unit");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "sets"
                        },
                        new
                        {
                            Id = 2,
                            Name = "reps"
                        },
                        new
                        {
                            Id = 3,
                            Name = "h"
                        },
                        new
                        {
                            Id = 4,
                            Name = "min"
                        },
                        new
                        {
                            Id = 5,
                            Name = "sec"
                        },
                        new
                        {
                            Id = 6,
                            Name = "kg"
                        },
                        new
                        {
                            Id = 7,
                            Name = "lb"
                        },
                        new
                        {
                            Id = 8,
                            Name = "speed"
                        },
                        new
                        {
                            Id = 9,
                            Name = "incline"
                        },
                        new
                        {
                            Id = 10,
                            Name = "steps"
                        });
                });

            modelBuilder.Entity("Harmony.Fitness.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeletedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Weekday")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("Harmony.Fitness.Models.Exercise", b =>
                {
                    b.HasOne("Harmony.Fitness.Models.Workout", "Workout")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Harmony.Fitness.Models.ExerciseProperty", b =>
                {
                    b.HasOne("Harmony.Fitness.Models.Exercise", "Exercise")
                        .WithMany("Properties")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("Harmony.Fitness.Models.ExerciseSuggestionUnit", b =>
                {
                    b.HasOne("Harmony.Fitness.Models.ExerciseSuggestion", "ExerciseSuggestion")
                        .WithMany("ExerciseSuggestionUnits")
                        .HasForeignKey("ExerciseSuggestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Harmony.Fitness.Models.Unit", "Unit")
                        .WithMany("ExerciseSuggestionUnits")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseSuggestion");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Harmony.Fitness.Models.Exercise", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Harmony.Fitness.Models.ExerciseSuggestion", b =>
                {
                    b.Navigation("ExerciseSuggestionUnits");
                });

            modelBuilder.Entity("Harmony.Fitness.Models.Unit", b =>
                {
                    b.Navigation("ExerciseSuggestionUnits");
                });

            modelBuilder.Entity("Harmony.Fitness.Models.Workout", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
