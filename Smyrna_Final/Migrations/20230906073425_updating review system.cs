using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smyrna_Prototype.Migrations
{
    public partial class updatingreviewsystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPosted",
                table: "CustomerReviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "76de97d6-0a0c-4be3-826b-7c133717cdb6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a952f27-5bd4-48c4-b1c2-fab3586a106c", "AQAAAAEAACcQAAAAEBMG7SLh/f6CB18nV+MutqJqDUChJ3MbP+5TFozPnQ5TixecmFZpmzpWtseDn2QE5A==", "36464800-2967-4d5c-a22f-500c7a8a892d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPosted",
                table: "CustomerReviews");

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
    }
}
