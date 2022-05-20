using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProject001.DAL.Migrations
{
    public partial class book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pages = table.Column<int>(type: "int", nullable: false),
                    wordCount = table.Column<double>(type: "float", nullable: false),
                    binding = table.Column<bool>(type: "bit", nullable: false),
                    releaseYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    authorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.bookId);
                    table.ForeignKey(
                        name: "FK_Book_Author_authorId",
                        column: x => x.authorId,
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_authorId",
                table: "Book",
                column: "authorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
