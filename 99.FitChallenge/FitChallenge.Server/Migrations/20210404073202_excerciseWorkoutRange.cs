using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitChallenge.Server.Migrations
{
    public partial class excerciseWorkoutRange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Repetitions",
                table: "ExcerciseWorkouts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 4, 7, 32, 2, 365, DateTimeKind.Utc).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 4, 7, 32, 2, 365, DateTimeKind.Utc).AddTicks(8206));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 4, 7, 32, 2, 365, DateTimeKind.Utc).AddTicks(8210));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 4, 7, 32, 2, 365, DateTimeKind.Utc).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 4, 7, 32, 2, 365, DateTimeKind.Utc).AddTicks(8213));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 4, 7, 32, 2, 365, DateTimeKind.Utc).AddTicks(8259));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Repetitions",
                table: "ExcerciseWorkouts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 59, 34, 427, DateTimeKind.Utc).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 59, 34, 427, DateTimeKind.Utc).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 59, 34, 427, DateTimeKind.Utc).AddTicks(8449));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 59, 34, 427, DateTimeKind.Utc).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 59, 34, 427, DateTimeKind.Utc).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 59, 34, 427, DateTimeKind.Utc).AddTicks(8456));
        }
    }
}
