using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Classification = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseName = table.Column<string>(type: "TEXT", nullable: true),
                    Grades = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "Classification", "FirstName", "LastName" },
                values: new object[] { 1, 23, 1, "Kevin", "Huynh" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "Classification", "FirstName", "LastName" },
                values: new object[] { 2, 23, 2, "Dummy", "Name" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "Classification", "FirstName", "LastName" },
                values: new object[] { 3, 30, 4, "Water", "CAP" });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "Grades", "StudentId" },
                values: new object[] { 1, "Calculus", 100f, 1 });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "Grades", "StudentId" },
                values: new object[] { 2, "Physics", 90f, 1 });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "Grades", "StudentId" },
                values: new object[] { 3, "Writing", 30f, 1 });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "Grades", "StudentId" },
                values: new object[] { 4, "Speech", 50f, 1 });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "Grades", "StudentId" },
                values: new object[] { 5, "Calculus", 10f, 2 });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "Grades", "StudentId" },
                values: new object[] { 6, "Physics", 20f, 2 });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "Grades", "StudentId" },
                values: new object[] { 7, "Writing", 30f, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentId",
                table: "Grade",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
