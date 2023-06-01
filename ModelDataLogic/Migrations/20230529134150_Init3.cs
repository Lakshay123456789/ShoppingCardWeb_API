using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelDataLogic.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f750bcc-cc4d-45a3-ba50-0c50cfc494e3", "AQAAAAEAACcQAAAAENPxhN5UEX9B22IjSV+E6jKj4dZlnYH1PGnAZcaO3luuvPoY7ScyGT59jQn8gzv36g==", "82dd1271-97ff-497d-8a70-2a1f1e5de7ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1094c346-30b0-41d0-aab1-085a14079785", "AQAAAAEAACcQAAAAEHG+Lt37XXomdZ6D5QCPUJ2nziecEKEiQBtP20G/fa9O8oourep8sLi9JGGFa5OeZA==", "033c4d8f-b6da-4375-83e4-1de14133a94c" });
        }
    }
}
