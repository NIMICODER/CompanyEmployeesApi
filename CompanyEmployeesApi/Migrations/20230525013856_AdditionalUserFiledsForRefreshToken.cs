using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployeesApi.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalUserFiledsForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3387213c-b51a-495b-afef-48c9b00bdb60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c170c436-3a2d-46e6-86e5-22bc7586cbeb");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4cc0ccba-ad89-4767-8ae2-e9b6e11ab340", "b8d4ab7f-f664-4c9b-b35e-24ce195915be", "Administrator", "ADMINISTRATOR" },
                    { "69be10f1-21c3-4cdd-8477-86d9dd2dc337", "94132302-ec80-4817-9c8c-e9ecebfde88a", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cc0ccba-ad89-4767-8ae2-e9b6e11ab340");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69be10f1-21c3-4cdd-8477-86d9dd2dc337");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3387213c-b51a-495b-afef-48c9b00bdb60", "eacf3b08-63e8-41ff-be86-1c4ca032e178", "Manager", "MANAGER" },
                    { "c170c436-3a2d-46e6-86e5-22bc7586cbeb", "10445d20-a50a-42d9-8069-50c0ff0242c8", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
