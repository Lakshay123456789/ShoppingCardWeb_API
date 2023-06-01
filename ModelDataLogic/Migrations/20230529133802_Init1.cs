using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelDataLogic.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "50ddda8e-d4ed-40d4-8eac-40797826188a", "admin@gmail.com", false, "Admin", "Admin", false, null, null, null, "AQAAAAEAACcQAAAAEIAO8wYwHpRzFKd4RrmKoiO5sLideP4YeEd+J1YwcCqV+j1sJXmOoPJx7u25NXSkHA==", null, false, "82e3da37-ca75-4abd-97a3-4f430c6ac6bd", false, "admin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");
        }
    }
}
