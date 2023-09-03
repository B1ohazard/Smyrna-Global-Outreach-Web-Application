using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smyrna_Prototype.Migrations
{
    public partial class productvalidationtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f44844f1-8dc7-401b-a053-db7d90a496c1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3590839c-3dd3-4780-b19f-9b37929ca780", "AQAAAAEAACcQAAAAEDE/i00r1IjiNg4LB6B5Jq2ilOprdhn1wn7xFgcxP0r1SkUJcr/bi8dyVz3ffYbC1w==", "f45b18ad-2bd1-4a80-b686-d9e8d2ef049d" });
        }
    }
}
