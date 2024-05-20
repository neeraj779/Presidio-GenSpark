using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRequestTrackerAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RaisedByEmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestNumber);
                    table.ForeignKey(
                        name: "FK_Request_Employees_RaisedByEmployeeId",
                        column: x => x.RaisedByEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHashKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "Image", "Name", "Phone", "Role" },
                values: new object[,]
                {
                    { 101, new DateTime(2000, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ramu", "9876543321", "Admin" },
                    { 102, new DateTime(2002, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Somu", "9988776655", "User" },
                    { 103, new DateTime(2001, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Ravi", "9876543210", "User" },
                    { 104, new DateTime(2003, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Raju", "9988776655", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_RaisedByEmployeeId",
                table: "Request",
                column: "RaisedByEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
