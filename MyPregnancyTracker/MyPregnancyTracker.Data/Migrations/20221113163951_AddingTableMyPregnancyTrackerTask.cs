using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPregnancyTracker.Data.Migrations
{
    public partial class AddingTableMyPregnancyTrackerTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyPregnancyTrackerTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GestationalWeekId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyPregnancyTrackerTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyPregnancyTrackerTask_GestationalWeek_GestationalWeekId",
                        column: x => x.GestationalWeekId,
                        principalTable: "GestationalWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserMyPregnancyTrackerTask",
                columns: table => new
                {
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    MyPregnancyTrackerTaskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserMyPregnancyTrackerTask", x => new { x.MyPregnancyTrackerTaskId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserMyPregnancyTrackerTask_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserMyPregnancyTrackerTask_MyPregnancyTrackerTask_MyPregnancyTrackerTaskId",
                        column: x => x.MyPregnancyTrackerTaskId,
                        principalTable: "MyPregnancyTrackerTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserMyPregnancyTrackerTask_ApplicationUserId",
                table: "ApplicationUserMyPregnancyTrackerTask",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyPregnancyTrackerTask_GestationalWeekId",
                table: "MyPregnancyTrackerTask",
                column: "GestationalWeekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserMyPregnancyTrackerTask");

            migrationBuilder.DropTable(
                name: "MyPregnancyTrackerTask");
        }
    }
}
