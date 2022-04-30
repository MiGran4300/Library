using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class statusBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Authors");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
