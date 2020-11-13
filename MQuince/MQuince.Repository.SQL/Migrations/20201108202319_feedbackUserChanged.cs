using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MQuince.Repository.SQL.Migrations
{
    public partial class feedbackUserChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Feedback");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Feedback",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Feedback");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Feedback",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
