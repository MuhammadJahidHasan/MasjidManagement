using Microsoft.EntityFrameworkCore.Migrations;

namespace MasjidManagement.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Musollies",
                columns: new[] { "Id", "Department", "Name" },
                values: new object[] { 1, 3, "Jahid" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musollies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
