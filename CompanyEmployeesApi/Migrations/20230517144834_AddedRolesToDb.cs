using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployeesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "837602cb-ff5b-4ce0-9874-b66094c16193");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e664a870-000f-4a61-8835-35eed72bffb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cf718095-6f2e-4bc3-a45f-cce8cade834a", "c6966d4a-2f03-4f9d-8faf-3a493f327bef", "Administrator", "ADMINISTRATOR" },
                    { "ead5aaf0-aea9-461c-86ca-ec65c96a3f51", "d2345135-de13-41fd-9acb-0e27d05d5770", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf718095-6f2e-4bc3-a45f-cce8cade834a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ead5aaf0-aea9-461c-86ca-ec65c96a3f51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "837602cb-ff5b-4ce0-9874-b66094c16193", "06e77c2e-117d-44de-ae14-35234b0d6df3", "Administrator", "ADMINISTRATOR" },
                    { "e664a870-000f-4a61-8835-35eed72bffb4", "f09dc9c0-af90-4620-afcd-18fb18071ba5", "Manager", "MANAGER" }
                });
        }
    }
}
