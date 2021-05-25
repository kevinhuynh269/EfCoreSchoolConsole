using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddedanewStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Grades",
                table: "Grade",
                newName: "GradeScore");

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Age", "Classification", "FirstName", "LastName" },
                values: new object[] { 4, 18, 2, "Sophie", "More" });

            migrationBuilder.InsertData(
                table: "Grade",
                columns: new[] { "Id", "CourseName", "GradeScore", "StudentId" },
                values: new object[] { 8, "Writing", 80f, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Grade",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "GradeScore",
                table: "Grade",
                newName: "Grades");
        }
    }
}
