using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harmony.Fitness.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseSuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSuggestions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weekday = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseSuggestionUnit",
                columns: table => new
                {
                    ExerciseSuggestionId = table.Column<int>(type: "int", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSuggestionUnit", x => new { x.ExerciseSuggestionId, x.UnitId });
                    table.ForeignKey(
                        name: "FK_ExerciseSuggestionUnit_ExerciseSuggestions_ExerciseSuggestionId",
                        column: x => x.ExerciseSuggestionId,
                        principalTable: "ExerciseSuggestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseSuggestionUnit_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseDetails_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExerciseSuggestions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Plank" },
                    { 2, "Lat pull down" },
                    { 3, "Hip thrust" },
                    { 4, "Glute kickbacks" },
                    { 5, "Side leg lifts" },
                    { 6, "Lunges" },
                    { 7, "Reverse lunges" },
                    { 8, "Warm up" },
                    { 9, "Stretching" },
                    { 10, "Shoulder press" },
                    { 11, "Squats" },
                    { 12, "Bicep curls" },
                    { 13, "Hip" },
                    { 14, "Plank hip dips" },
                    { 15, "Treadmil" },
                    { 16, "Lat raise" },
                    { 17, "DB chest press" },
                    { 18, "Knee push up" },
                    { 19, "Dead bugs" },
                    { 20, "Steps" },
                    { 21, "Russian Twist" },
                    { 22, "Single leg deadlift" }
                });

            migrationBuilder.InsertData(
                table: "Unit",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "sets" },
                    { 2, "reps" },
                    { 3, "h" },
                    { 4, "min" },
                    { 5, "sec" },
                    { 6, "kg" },
                    { 7, "lb" },
                    { 8, "speed" },
                    { 9, "incline" },
                    { 10, "steps" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseSuggestionUnit",
                columns: new[] { "ExerciseSuggestionId", "UnitId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 6 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 6 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 6 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 6 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 6 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 6 },
                    { 8, 4 },
                    { 9, 4 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 6 },
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 6 },
                    { 12, 1 },
                    { 12, 2 },
                    { 12, 6 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 6 },
                    { 14, 1 },
                    { 14, 2 },
                    { 14, 6 },
                    { 15, 3 },
                    { 15, 4 },
                    { 15, 6 },
                    { 15, 8 }
                });

            migrationBuilder.InsertData(
                table: "ExerciseSuggestionUnit",
                columns: new[] { "ExerciseSuggestionId", "UnitId" },
                values: new object[,]
                {
                    { 15, 9 },
                    { 16, 1 },
                    { 16, 2 },
                    { 16, 6 },
                    { 17, 1 },
                    { 17, 2 },
                    { 17, 6 },
                    { 18, 1 },
                    { 18, 2 },
                    { 18, 6 },
                    { 19, 1 },
                    { 19, 2 },
                    { 19, 6 },
                    { 20, 10 },
                    { 21, 1 },
                    { 21, 2 },
                    { 21, 6 },
                    { 22, 1 },
                    { 22, 2 },
                    { 22, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_WorkoutId",
                table: "Exercise",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDetails_ExerciseId",
                table: "ExerciseDetails",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSuggestionUnit_UnitId",
                table: "ExerciseSuggestionUnit",
                column: "UnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseDetails");

            migrationBuilder.DropTable(
                name: "ExerciseSuggestionUnit");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "ExerciseSuggestions");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Workouts");
        }
    }
}
