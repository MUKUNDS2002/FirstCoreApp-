using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherAge = table.Column<int>(type: "int", nullable: false),
                    TeacherCount = table.Column<int>(type: "int", nullable: false),
                    TeacherFaculty = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
