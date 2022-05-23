using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Haslo.Data.Migrations
{
    public partial class xdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Person");
        }
    }
}
