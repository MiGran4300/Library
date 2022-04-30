using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            

            

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Authors",
                type: "int",
                nullable: false,
                defaultValue: 0);

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Authors");

            
        }
    }
}
