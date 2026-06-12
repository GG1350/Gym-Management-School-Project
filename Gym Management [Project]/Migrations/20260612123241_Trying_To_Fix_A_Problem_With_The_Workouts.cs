using Microsoft.EntityFrameworkCore.Migrations;

namespace Gym_Management__Project_.Migrations
{
    public partial class Trying_To_Fix_A_Problem_With_The_Workouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "DurationMinutes",
            //    table: "Exercises");

            //migrationBuilder.DropColumn(
            //    name: "MET",
            //    table: "Exercises");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Workouts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Workouts");

            //migrationBuilder.AddColumn<int>(
            //    name: "DurationMinutes",
            //    table: "Exercises",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<double>(
            //    name: "MET",
            //    table: "Exercises",
            //    type: "float",
            //    nullable: false,
            //    defaultValue: 0.0);
        }
    }
}
