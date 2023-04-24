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
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f20bcf92-3ff4-4de0-b28a-600c288b8731", "52b23a29-40b5-4870-94fb-63a5988d5ba8", "Administrator", "ADMINISTRATOR" },
                    { "f33839db-0038-484f-a698-112640f8aac5", "ec8646fa-0d46-4e0b-8b66-e78d2092657a", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f20bcf92-3ff4-4de0-b28a-600c288b8731");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33839db-0038-484f-a698-112640f8aac5");
        }
    }
}
