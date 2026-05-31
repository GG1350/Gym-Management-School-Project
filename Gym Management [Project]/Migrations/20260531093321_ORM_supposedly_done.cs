using Microsoft.EntityFrameworkCore.Migrations;

namespace Gym_Management__Project_.Migrations
{
    public partial class ORM_supposedly_done : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Workouts_WorkoutPlanId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Trainers_Id",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Trainers_TrainersId1",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Members_MembersId",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Members_MembersId1",
                table: "Workouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Trainers_TrainersId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_MembersId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_MembersId1",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_TrainersId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Members_TrainersId1",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_WorkoutPlanId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "MembersId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "MembersId1",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "TrainersId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "TrainersId1",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "WorkoutPlanId",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Workouts",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Trainers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Trainers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Members",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Members",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Members",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TranerId",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutId",
                table: "Exercises",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_MemberId",
                table: "Workouts",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TranerId",
                table: "Members",
                column: "TranerId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises",
                column: "WorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Trainers_TranerId",
                table: "Members",
                column: "TranerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Members_MemberId",
                table: "Workouts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Workouts_WorkoutId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Trainers_TranerId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Members_MemberId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_MemberId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Members_TranerId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_WorkoutId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TranerId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "WorkoutId",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Workouts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "MembersId",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembersId1",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainersId",
                table: "Workouts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Trainers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Members",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TrainersId1",
                table: "Members",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutPlanId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_MembersId",
                table: "Workouts",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_MembersId1",
                table: "Workouts",
                column: "MembersId1");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_TrainersId",
                table: "Workouts",
                column: "TrainersId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_TrainersId1",
                table: "Members",
                column: "TrainersId1");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_WorkoutPlanId",
                table: "Exercises",
                column: "WorkoutPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Workouts_WorkoutPlanId",
                table: "Exercises",
                column: "WorkoutPlanId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Trainers_Id",
                table: "Members",
                column: "Id",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Trainers_TrainersId1",
                table: "Members",
                column: "TrainersId1",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Members_MembersId",
                table: "Workouts",
                column: "MembersId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Members_MembersId1",
                table: "Workouts",
                column: "MembersId1",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Trainers_TrainersId",
                table: "Workouts",
                column: "TrainersId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
