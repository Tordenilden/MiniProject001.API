using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProject001.DAL.Migrations
{
    public partial class teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    teacherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.teacherId);
                });

            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false),
                    teacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.studentId, x.teacherId });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Teacher_teacherId",
                        column: x => x.teacherId,
                        principalTable: "Teacher",
                        principalColumn: "teacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_teacherId",
                table: "StudentTeacher",
                column: "teacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTeacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
