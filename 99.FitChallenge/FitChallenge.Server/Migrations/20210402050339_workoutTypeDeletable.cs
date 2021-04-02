using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FitChallenge.Server.Migrations
{
    public partial class workoutTypeDeletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "WorkoutTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "WorkoutTypes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WorkoutTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "WorkoutTypes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "WorkoutTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WorkoutTypes");

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 3, 29, 15, 36, 33, 816, DateTimeKind.Utc).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 3, 29, 15, 36, 33, 816, DateTimeKind.Utc).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 3, 29, 15, 36, 33, 816, DateTimeKind.Utc).AddTicks(9505));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 3, 29, 15, 36, 33, 816, DateTimeKind.Utc).AddTicks(9551));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 3, 29, 15, 36, 33, 816, DateTimeKind.Utc).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "WorkoutTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 3, 29, 15, 36, 33, 816, DateTimeKind.Utc).AddTicks(9558));
        }
    }
}
