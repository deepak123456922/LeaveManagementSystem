using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultRolesandUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f61b8e5-3ebd-4fd9-9790-2450ca560688", "3", "Administrator", "ADMINISTRATOR" },
                    { "450c8bef-99a1-4533-ac74-aec5466032d4", "1", "Employee", "EMPLOYEE" },
                    { "c498bdfc-9c3f-4329-b93e-0b47afd0f008", "2", "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f2bf8027-b6a5-4f21-8d96-f618898ca6fa", 0, "CONCURRENCY_STAMP_1", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEBf9KA9PCyBLHChSxfo1Wuw/S4ievDq0ehqwrOD9WwdK8x37QCZe31nfoPI9CvdClw==", null, false, "SECURITY_STAMP_1", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3f61b8e5-3ebd-4fd9-9790-2450ca560688", "f2bf8027-b6a5-4f21-8d96-f618898ca6fa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "450c8bef-99a1-4533-ac74-aec5466032d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c498bdfc-9c3f-4329-b93e-0b47afd0f008");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3f61b8e5-3ebd-4fd9-9790-2450ca560688", "f2bf8027-b6a5-4f21-8d96-f618898ca6fa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f61b8e5-3ebd-4fd9-9790-2450ca560688");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f2bf8027-b6a5-4f21-8d96-f618898ca6fa");
        }
    }
}
