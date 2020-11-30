using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MQuince.IntegrationMySQL.Migrations
{
    public partial class initiall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicationsConsumption",
                columns: table => new
                {
                    KeyConsumtion = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    DateOfConsumtion = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationsConsumption", x => x.KeyConsumtion);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacy",
                columns: table => new
                {
                    ApiKey = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacy", x => x.ApiKey);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicationsConsumption");

            migrationBuilder.DropTable(
                name: "Pharmacy");
        }
    }
}
