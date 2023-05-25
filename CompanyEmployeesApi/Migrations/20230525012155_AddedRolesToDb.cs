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
                    { "3387213c-b51a-495b-afef-48c9b00bdb60", "eacf3b08-63e8-41ff-be86-1c4ca032e178", "Manager", "MANAGER" },
                    { "c170c436-3a2d-46e6-86e5-22bc7586cbeb", "10445d20-a50a-42d9-8069-50c0ff0242c8", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3387213c-b51a-495b-afef-48c9b00bdb60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c170c436-3a2d-46e6-86e5-22bc7586cbeb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "68c94fbd-003b-4681-a7a7-42aa29201ab2", "a5ba4477-a3f6-4ede-9292-f2efd9d779f3", "Manager", "MANAGER" },
                    { "df794f23-720d-4064-85e4-2d63ea185c66", "1c7eba32-b445-408a-851f-b2e72a84fb8a", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
