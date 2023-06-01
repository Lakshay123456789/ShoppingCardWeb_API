using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModelDataLogic.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    ProductQuality = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e667d06-9d12-4266-a473-b60fe7c03bc4", "AQAAAAEAACcQAAAAEBeChcHbwiJm9x+3QKM69o4ChUdS39rzvd55bKtrLJJ1pkjwFo7wioCm2iEahnzqSQ==", "87b76950-3631-448d-988b-d912ad3ad3a1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f750bcc-cc4d-45a3-ba50-0c50cfc494e3", "AQAAAAEAACcQAAAAENPxhN5UEX9B22IjSV+E6jKj4dZlnYH1PGnAZcaO3luuvPoY7ScyGT59jQn8gzv36g==", "82dd1271-97ff-497d-8a70-2a1f1e5de7ae" });
        }
    }
}
