using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1aa120a-0b28-4438-a0ed-b98688a1add5", "136049d5-ea56-458b-af92-216bfc097e55", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "12111ff3-49bc-44ac-bd68-bb9bb7ddc959", 0, null, "457e4232-25bc-4090-b690-2f8877497fb2", "admin@gmail.com", false, "admin", "admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELv8uzxSWcCBwNvSfl/aZq3FwBilR7hNH5LrChUDHnghiS0YqAvb5E9KPZYied4Cyg==", null, "1234567890", false, "9c089058-8298-4190-abfc-ae38d06ec1de", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b1aa120a-0b28-4438-a0ed-b98688a1add5", "12111ff3-49bc-44ac-bd68-bb9bb7ddc959" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b1aa120a-0b28-4438-a0ed-b98688a1add5", "12111ff3-49bc-44ac-bd68-bb9bb7ddc959" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1aa120a-0b28-4438-a0ed-b98688a1add5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12111ff3-49bc-44ac-bd68-bb9bb7ddc959");
        }
    }
}
