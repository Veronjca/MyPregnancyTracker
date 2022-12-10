using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPregnancyTracker.Data.Migrations
{
    public partial class ChangingUserArticleIsLikedPropertyToBeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsLiked",
                table: "UserArticle",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ecf5ef1c-7284-47c8-ac76-c339a7e2c058");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7bbf04ce-9ee2-46e4-8e37-678ea3e88657");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsLiked",
                table: "UserArticle",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "79cf7ef0-1d51-4966-86a8-b9cf54725ccd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8af2fd83-cc82-4704-bd16-702e22049bcd");
        }
    }
}
