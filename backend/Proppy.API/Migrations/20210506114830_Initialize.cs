using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                    ID = table.Column<int>(type: "int", maxLength: 19, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    { "D", "Designer" },
                    { "E", "CEO" },
                    { "F", "COO" },
                    { "G", "CTO" },
                    { "H", "CMO" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "DOB", "Email", "Gender", "Name", "Phone_No", "Photo", "Position_Code", "Remarks", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(1970, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc@gmail.com", "F", "Mary Tan", "0161234567", "https://images.unsplash.com/1", "A", "", 5000m },
                    { 9, new DateTime(1978, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc5@gmail.com", "F", "Vivian Chong", "0161234575", "https://images.unsplash.com/9", "F", "", 7000m },
                    { 10, new DateTime(1979, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz5@yahoo.com", "F", "Shirley Tan Wai Ling", "0161234576", "https://images.unsplash.com/10", "E", "", 8000m },
                    { 17, new DateTime(1986, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc49@gmail.com", "M", "Ken yoong 2", "+501612345712", "https://images.unsplash.com/17", "D", "", 2550m },
                    { 15, new DateTime(1984, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc39@gmail.com", "F", "Angela Baby 2", "01612345712", "https://images.unsplash.com/15", "D", "", 2700m },
                    { 7, new DateTime(1976, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc4@gmail.com", "M", "Ken yoong", "+50161234571", "https://images.unsplash.com/7", "D", "", 2550m },
                    { 5, new DateTime(1974, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc3@gmail.com", "F", "Angela Baby", "0161234571", "https://images.unsplash.com/5", "D", "", 2700m },
                    { 16, new DateTime(1985, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz39@yahoo.com", "M", "Mohd Rizal 2", "+801612345692", "https://images.unsplash.com/16", "C", "", 2500m },
                    { 14, new DateTime(1983, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz29@yahoo.com", "M", "Chow Yun Fatt 2", "01612345702", "https://images.unsplash.com/14", "C", "", 2800m },
                    { 6, new DateTime(1975, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz3@yahoo.com", "M", "Mohd Rizal", "+80161234569", "https://images.unsplash.com/6", "C", "", 2500m },
                    { 4, new DateTime(1973, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz2@yahoo.com", "M", "Chow Yun Fatt", "0161234570", "https://images.unsplash.com/4", "C", "", 2800m },
                    { 13, new DateTime(1982, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc29@gmail.com", "M", "Justin Biieber 2", "01612345692", "https://images.unsplash.com/13", "B", "", 3300m },
                    { 12, new DateTime(1981, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz9@yahoo.com", "M", "Aliasgar 2", "+601612345682", "https://images.unsplash.com/12", "B", "", 3500m },
                    { 3, new DateTime(1972, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc2@gmail.com", "M", "Justin Biieber", "0161234569", "https://images.unsplash.com/3", "B", "", 3300m },
                    { 2, new DateTime(1971, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz@yahoo.com", "M", "Aliasgar", "+60161234568", "https://images.unsplash.com/2", "B", "", 3500m },
                    { 18, new DateTime(1987, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz49@yahoo.com", "M", "Willson Wong 2", "+441612345332", "https://images.unsplash.com/18", "A", "", 5500m },
                    { 11, new DateTime(1980, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc9@gmail.com", "F", "Mary Tan 2", "01612345672", "https://images.unsplash.com/11", "A", "", 5000m },
                    { 8, new DateTime(1977, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz4@yahoo.com", "M", "Willson Wong", "+44161234533", "https://images.unsplash.com/8", "A", "", 5500m },
                    { 19, new DateTime(1988, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abc59@gmail.com", "F", "Vivian Chong 2", "01612345752", "https://images.unsplash.com/19", "G", "", 7000m },
                    { 20, new DateTime(1989, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "xyz59@yahoo.com", "F", "Shirley Tan Wai Ling 2", "01612345762", "https://images.unsplash.com/20", "H", "", 8000m }
                });

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
