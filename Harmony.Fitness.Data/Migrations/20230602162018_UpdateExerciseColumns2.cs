using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Harmony.Fitness.Data.Migrations
{
    public partial class UpdateExerciseColumns2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Exercise",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Exercise");
        }
    }
}
