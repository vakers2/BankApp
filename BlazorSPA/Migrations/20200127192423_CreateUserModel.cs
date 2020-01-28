using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorSPA.Migrations
{
    public partial class CreateUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Birthplace",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CitizenshipId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisabilityId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FamilyPositionId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Income",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Military",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PassportGiveDate",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PassportGiver",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportNumber",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PassportSeries",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Pensioner",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneHome",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneMobile",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Sex",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkPosition",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Workplace",
                table: "Employees",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Citizenship_CitizenshipId",
                table: "Employees",
                column: "CitizenshipId",
                principalTable: "Citizenship",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_City_CityId",
                table: "Employees",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Disability_DisabilityId",
                table: "Employees",
                column: "DisabilityId",
                principalTable: "Disability",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_FamilyPosition_FamilyPositionId",
                table: "Employees",
                column: "FamilyPositionId",
                principalTable: "FamilyPosition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Citizenship_CitizenshipId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_City_CityId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Disability_DisabilityId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_FamilyPosition_FamilyPositionId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Citizenship");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Disability");

            migrationBuilder.DropTable(
                name: "FamilyPosition");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CitizenshipId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DisabilityId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_FamilyPositionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Birthplace",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CitizenshipId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DisabilityId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FamilyPositionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Income",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Military",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PassportGiveDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PassportGiver",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PassportNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PassportSeries",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Pensioner",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneHome",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PhoneMobile",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkPosition",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Workplace",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
