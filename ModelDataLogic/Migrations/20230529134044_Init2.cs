using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelDataLogic.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "2", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "1", "Admin", "Admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1094c346-30b0-41d0-aab1-085a14079785", "AQAAAAEAACcQAAAAEHG+Lt37XXomdZ6D5QCPUJ2nziecEKEiQBtP20G/fa9O8oourep8sLi9JGGFa5OeZA==", "033c4d8f-b6da-4375-83e4-1de14133a94c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab4fac1-c546-41de-aebc-a14da6895711");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50ddda8e-d4ed-40d4-8eac-40797826188a", "AQAAAAEAACcQAAAAEIAO8wYwHpRzFKd4RrmKoiO5sLideP4YeEd+J1YwcCqV+j1sJXmOoPJx7u25NXSkHA==", "82e3da37-ca75-4abd-97a3-4f430c6ac6bd" });
        }
    }
}
