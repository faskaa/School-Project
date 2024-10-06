using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Migrations
{
    public partial class AddedAgeColumnToStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Suename",
                table: "Telebeler",
                newName: "Surname");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Telebeler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Telebeler");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Telebeler",
                newName: "Suename");
        }
    }
}
