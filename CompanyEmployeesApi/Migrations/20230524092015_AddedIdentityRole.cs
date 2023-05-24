using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployeesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e92a543-2945-4a72-bcc7-ae507e197b87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "772a4d3f-c22c-45c6-b785-20e3eca0c9d7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68c94fbd-003b-4681-a7a7-42aa29201ab2", "a5ba4477-a3f6-4ede-9292-f2efd9d779f3", "Manager", "MANAGER" },
                    { "df794f23-720d-4064-85e4-2d63ea185c66", "1c7eba32-b445-408a-851f-b2e72a84fb8a", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68c94fbd-003b-4681-a7a7-42aa29201ab2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df794f23-720d-4064-85e4-2d63ea185c66");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e92a543-2945-4a72-bcc7-ae507e197b87", "e0b5153a-cf21-40ab-af5f-7915e908483e", "Administrator", "ADMINISTRATOR" },
                    { "772a4d3f-c22c-45c6-b785-20e3eca0c9d7", "fb24bc68-7542-45e2-97aa-d2f4ef1cf96d", "Manager", "MANAGER" }
                });
        }
    }
}
