using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class AdjustModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citizenship",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizenship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disability",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyPosition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<bool>(nullable: false),
                    PassportSeries = table.Column<string>(nullable: false),
                    PassportNumber = table.Column<string>(nullable: false),
                    PassportGiver = table.Column<string>(nullable: false),
                    PassportGiveDate = table.Column<DateTime>(nullable: false),
                    IdentityNumber = table.Column<string>(nullable: false),
                    Birthplace = table.Column<string>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    PhoneHome = table.Column<string>(nullable: true),
                    PhoneMobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Workplace = table.Column<string>(nullable: true),
                    WorkPosition = table.Column<string>(nullable: true),
                    FamilyPositionId = table.Column<int>(nullable: false),
                    CitizenshipId = table.Column<int>(nullable: false),
                    DisabilityId = table.Column<int>(nullable: false),
                    Pensioner = table.Column<bool>(nullable: false),
                    Income = table.Column<int>(nullable: false),
                    Military = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Citizenship_CitizenshipId",
                        column: x => x.CitizenshipId,
                        principalTable: "Citizenship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Disability_DisabilityId",
                        column: x => x.DisabilityId,
                        principalTable: "Disability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_FamilyPosition_FamilyPositionId",
                        column: x => x.FamilyPositionId,
                        principalTable: "FamilyPosition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CitizenshipId",
                table: "Employees",
                column: "CitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CityId",
                table: "Employees",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DisabilityId",
                table: "Employees",
                column: "DisabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FamilyPositionId",
                table: "Employees",
                column: "FamilyPositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Citizenship");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Disability");

            migrationBuilder.DropTable(
                name: "FamilyPosition");
        }
    }
}
