using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smyrna_Prototype.Migrations
{
    public partial class Adminreviewfunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddReviews",
                columns: table => new
                {
                    AddReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerReview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddReviews", x => x.AddReviewId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "d120206f-98b4-42df-b6e6-8b0404b149e0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9dfbd98-e4af-49b5-8814-d35316d1e894", "AQAAAAEAACcQAAAAEB2JzqjuEQUOlGeZO3GtHebyXXUbb2Pr9qBPM5FJpH+tOBlTkQp++votnqmIeOB00w==", "601cbab6-3a49-4eb3-9e67-174fc24fd1f2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddReviews");

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
    }
}
