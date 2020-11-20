using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MQuince.Repository.SQL.Migrations
{
    public partial class initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorSurvey",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    OneStar = table.Column<int>(nullable: false),
                    TwoStar = table.Column<int>(nullable: false),
                    ThreeStar = table.Column<int>(nullable: false),
                    FourStar = table.Column<int>(nullable: false),
                    FiveStar = table.Column<int>(nullable: false),
                    QuestionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSurvey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSurvey_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSurvey_QuestionId",
                table: "DoctorSurvey",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSurvey");
        }
    }
}
