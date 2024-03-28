using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlappyBird.Migrations
{
    public partial class modifScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Visibilité",
                table: "Score",
                newName: "IsPublic");

            migrationBuilder.RenameColumn(
                name: "Temps",
                table: "Score",
                newName: "TimeInSeconds");

            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Score",
                newName: "ScoreValue");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Score",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Score",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Score_UserId",
                table: "Score",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Score_AspNetUsers_UserId",
                table: "Score",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Score_AspNetUsers_UserId",
                table: "Score");

            migrationBuilder.DropIndex(
                name: "IX_Score_UserId",
                table: "Score");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Score");

            migrationBuilder.RenameColumn(
                name: "TimeInSeconds",
                table: "Score",
                newName: "Temps");

            migrationBuilder.RenameColumn(
                name: "ScoreValue",
                table: "Score",
                newName: "Point");

            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "Score",
                newName: "Visibilité");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Score",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
