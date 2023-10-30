using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smyrna_Prototype.Migrations
{
    public partial class CustomerReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerReviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerReviews", x => x.ReviewId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d31c1dc7-b6d3-417d-bdac-6b3ebad574e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f360ac2-b6b9-42c0-8687-3a73eaa2c219", "AQAAAAEAACcQAAAAEKl+I9UGC5cjrRzH1Glo2gFu6ZBwAajVyD6yrvHDBKcGjd87EgR9df72LimsaN4M4Q==", "0d44a793-4326-4a7b-b95b-8cf1e43d6dc2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerReviews");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "2a4ff812-e91f-4b56-9210-816e827be18e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1870d41b-8ce5-4478-bb38-6cd7461f4bc4", "AQAAAAEAACcQAAAAECGtxGeNs8WR055rD5/xMQmBFk43GW9pLxnFSV2/U3PyapubHG43NTjtdF9mHAGUHw==", "a4f67b83-244f-443f-ba11-61d76933f18b" });
        }
    }
}
