using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class addFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Books",
                newName: "Snippet");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Snippet",
                table: "Books",
                newName: "PhotoPath");
        }
    }
}
