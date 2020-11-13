using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MQuince.Repository.SQL.Migrations
{
    public partial class DBFeedbackChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Feedback");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Feedback");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Feedback",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Publish",
                table: "Feedback",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Publish",
                table: "Feedback");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Feedback",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Feedback",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Feedback",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
