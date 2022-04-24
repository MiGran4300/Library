using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class addRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.CreateTable(
                name: "BookComments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookComments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_BookComments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookComments_BookId",
                table: "BookComments",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookComments");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Department", "Email", "FullName", "Grade", "Phone" },
                values: new object[,]
                {
                    { 1, "Славянска филология", "carson@lib.not", "Иван Иванов", null, 88776655 },
                    { 2, "Славянска филология", "ptko@lib.not", "Петко Александров", null, 88445533 },
                    { 3, "Българска филология", "maja@lib.not", "Мая Александрова", null, 788945533 },
                    { 4, "Английска филология", "ivana@lib.not", "Ивана Илиева", null, 98495593 },
                    { 5, "Славянска филология", "stojan@lib.not", "Стоян Михайлов", null, 778475533 },
                    { 6, "Китайска филология", "dim@lib.not", "Димитър Петков", null, 99465543 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "AuthorID", "FilePath", "Ganre", "ReleaseDate", "Snippet", "Title" },
                values: new object[,]
                {
                    { 1, 3, "file1.docx", "Есе", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", "Две сестри" },
                    { 2, 2, "file2.docx", "Разказ", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", "Чужденецът" },
                    { 3, 1, "file3.docx", "Разказ", new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", "Суша" },
                    { 4, 4, "file4.docx", "Разказ", new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", "Безславни дни" },
                    { 5, 2, "file5.docx", "Новела", new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", "Призрачния кораб" },
                    { 6, 4, "file6.docx", "Стихотворение", new DateTime(2022, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Няма човек, който обича болката сама по себе си, търси я и я желае, само защото е болка...", "Мъртви цветя" }
                });
        }
    }
}
