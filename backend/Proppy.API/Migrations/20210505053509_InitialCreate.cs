using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proppy.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Description = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", maxLength: 19, nullable: false),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Phone_No = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Gender = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    Position_Code = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(type: "date", maxLength: 16, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(16)", maxLength: 16, nullable: false),
                    Remarks = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    Photo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_Position_Code",
                        column: x => x.Position_Code,
                        principalTable: "Positions",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Code", "Description" },
                values: new object[,]
                {
                    { "A", "Senior Manager" },
                    { "B", "Manager" },
                    { "C", "Engineer" },
                    { "D", "Designer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Position_Code",
                table: "Employees",
                column: "Position_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
