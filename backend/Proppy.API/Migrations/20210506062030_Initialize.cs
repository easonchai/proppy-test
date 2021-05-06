using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proppy.API.Migrations
{
    public partial class Initialize : Migration
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

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "DOB", "Email", "Gender", "Name", "Phone_No", "Photo", "Position_Code", "Remarks", "Salary" },
                values: new object[] { 1L, new DateTime(1970, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc@gmail.com", "F", "Mary Tan", "0161234567", "https://images.unsplash.com/1", "A", "", 5000m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "DOB", "Email", "Gender", "Name", "Phone_No", "Photo", "Position_Code", "Remarks", "Salary" },
                values: new object[] { 2L, new DateTime(1971, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz@yahoo.com", "M", "Aliasgar", "+60161234568", "https://images.unsplash.com/2", "B", "", 3500m });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "DOB", "Email", "Gender", "Name", "Phone_No", "Photo", "Position_Code", "Remarks", "Salary" },
                values: new object[] { 3L, new DateTime(1972, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc2@gmail.com", "M", "Justin Biieber", "0161234569", "https://images.unsplash.com/3", "B", "", 3300m });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ID",
                table: "Employees",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Phone_No",
                table: "Employees",
                column: "Phone_No",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Photo",
                table: "Employees",
                column: "Photo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Position_Code",
                table: "Employees",
                column: "Position_Code");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Code",
                table: "Positions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_Description",
                table: "Positions",
                column: "Description",
                unique: true);
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
