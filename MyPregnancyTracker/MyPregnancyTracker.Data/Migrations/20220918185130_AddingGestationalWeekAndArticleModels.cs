using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPregnancyTracker.Data.Migrations
{
    public partial class AddingGestationalWeekAndArticleModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Dislikes = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GestationalWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GestationalAge = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BabyPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BabyContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NutritionContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvicesPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvicesContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TasksPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TasksContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestationalWeek", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "GestationalWeek");
        }
    }
}
