using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlappyBird.Migrations
{
    public partial class User2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoreId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ScoreId",
                table: "AspNetUsers",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Score_ScoreId",
                table: "AspNetUsers",
                column: "ScoreId",
                principalTable: "Score",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Score_ScoreId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ScoreId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ScoreId",
                table: "AspNetUsers");
        }
    }
}
