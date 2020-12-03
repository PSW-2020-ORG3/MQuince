using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MQuince.Repository.SQL.Migrations
{
    public partial class testMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_ChosenDoctor",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_ChosenDoctor",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ChosenDoctor",
                table: "Patient");

            migrationBuilder.AddColumn<Guid>(
                name: "ChosenDoctorId",
                table: "Patient",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorPersistanceId",
                table: "Patient",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoctorPersistanceId",
                table: "Patient",
                column: "DoctorPersistanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_DoctorPersistanceId",
                table: "Patient",
                column: "DoctorPersistanceId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_Doctor_DoctorPersistanceId",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_DoctorPersistanceId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ChosenDoctorId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DoctorPersistanceId",
                table: "Patient");

            migrationBuilder.AddColumn<Guid>(
                name: "ChosenDoctor",
                table: "Patient",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ChosenDoctor",
                table: "Patient",
                column: "ChosenDoctor");

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_Doctor_ChosenDoctor",
                table: "Patient",
                column: "ChosenDoctor",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
