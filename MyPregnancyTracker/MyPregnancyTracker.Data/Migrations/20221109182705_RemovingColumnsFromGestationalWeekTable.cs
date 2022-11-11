using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPregnancyTracker.Data.Migrations
{
    public partial class RemovingColumnsFromGestationalWeekTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "GestationalWeek");

            migrationBuilder.DropColumn(
                name: "TasksContent",
                table: "GestationalWeek");

            migrationBuilder.DropColumn(
                name: "TasksPictureUrl",
                table: "GestationalWeek");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "GestationalWeek",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TasksContent",
                table: "GestationalWeek",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TasksPictureUrl",
                table: "GestationalWeek",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
