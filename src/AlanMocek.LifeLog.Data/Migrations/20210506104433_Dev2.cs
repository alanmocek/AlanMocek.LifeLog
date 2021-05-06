using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlanMocek.LifeLog.Data.Migrations
{
    public partial class Dev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value_Time",
                table: "ActivityRecords");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ActivityRecords",
                newName: "UpdatedAtUtc");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "DayRecords",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ActivityType",
                table: "ActivityRecords",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "ActivityRecords",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Value_Hours",
                table: "ActivityRecords",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value_Minutes",
                table: "ActivityRecords",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value_Seconds",
                table: "ActivityRecords",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "Activities",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAtUtc",
                table: "Activities",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "DayRecords");

            migrationBuilder.DropColumn(
                name: "ActivityType",
                table: "ActivityRecords");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "ActivityRecords");

            migrationBuilder.DropColumn(
                name: "Value_Hours",
                table: "ActivityRecords");

            migrationBuilder.DropColumn(
                name: "Value_Minutes",
                table: "ActivityRecords");

            migrationBuilder.DropColumn(
                name: "Value_Seconds",
                table: "ActivityRecords");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UpdatedAtUtc",
                table: "Activities");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                table: "ActivityRecords",
                newName: "Type");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Value_Time",
                table: "ActivityRecords",
                type: "TEXT",
                nullable: true);
        }
    }
}
