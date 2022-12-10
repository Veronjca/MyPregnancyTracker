using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPregnancyTracker.Data.Migrations
{
    public partial class ChangingColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GestationalWeek",
                table: "AspNetUsers",
                newName: "GestationalWeekAge");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GestationalWeekAge",
                table: "AspNetUsers",
                newName: "GestationalWeek");
        }
    }
}
