using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitChallenge.Server.Migrations
{
    public partial class excerciseWorkout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ExcerciseWorkouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ExcerciseWorkouts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "ExcerciseWorkouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ExcerciseWorkouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExecutionOrder",
                table: "ExcerciseWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExcerciseWorkouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "ExcerciseWorkouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ExcerciseWorkouts",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExcerciseWorkouts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ExcerciseWorkouts");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "ExcerciseWorkouts");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ExcerciseWorkouts");

            migrationBuilder.DropColumn(
                name: "ExecutionOrder",
                table: "ExcerciseWorkouts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExcerciseWorkouts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ExcerciseWorkouts");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ExcerciseWorkouts");

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 3, 38, 525, DateTimeKind.Utc).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 3, 38, 525, DateTimeKind.Utc).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 3, 38, 525, DateTimeKind.Utc).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 3, 38, 525, DateTimeKind.Utc).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 3, 38, 525, DateTimeKind.Utc).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 4, 2, 5, 3, 38, 525, DateTimeKind.Utc).AddTicks(3358));
        }
    }
}
