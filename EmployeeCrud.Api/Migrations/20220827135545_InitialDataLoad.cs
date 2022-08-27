using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeCrud.Api.Migrations
{
    public partial class InitialDataLoad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2000, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC", "PQR" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(2000, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "DEF", "PQR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
