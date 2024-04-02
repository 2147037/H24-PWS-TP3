using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlappyBird.Migrations
{
    public partial class scoreDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TimeInSeconds",
                table: "Score",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11111111-1111-1111-1111-111111111111", 0, "06893bf6-b54e-4644-90b4-a3928c2f8b2e", "paul@mail.com", false, false, null, "PAUL@MAIL.COM", "PAUL", "AQAAAAEAACcQAAAAEPyvFp+/zuVBh/jfAAHd7CJ6nw4uKEjXfcLfLatkyAwwvvnMnBEXWuGpAEdlMsLfXA==", null, false, "f58caa05-676f-4744-a3a4-35a66d4446ea", false, "Paul" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "11111111-1111-1111-1111-111111111112", 0, "d23148b0-9677-4a89-84d0-196d4f706352", "Ezat@mail.com", false, false, null, "EZAT@MAIL.COM", "EZAT", "AQAAAAEAACcQAAAAEL6OCX4/UTV9nvTSfQQHHUoL0ykwiNF73UuQ6bGNFWAi8XqGsHhGdgIayFZ0Ele+0g==", null, false, "41220729-136e-4c19-9913-afc6f50d0726", false, "Ezat" });

            migrationBuilder.InsertData(
                table: "Score",
                columns: new[] { "Id", "Date", "IsPublic", "ScoreValue", "TimeInSeconds", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 2, 10, 6, 58, 462, DateTimeKind.Local).AddTicks(6145), false, 14, 3.21, "11111111-1111-1111-1111-111111111111" },
                    { 2, new DateTime(2024, 4, 2, 10, 6, 58, 462, DateTimeKind.Local).AddTicks(6183), true, 144, 32.109999999999999, "11111111-1111-1111-1111-111111111111" },
                    { 3, new DateTime(2024, 4, 2, 10, 6, 58, 462, DateTimeKind.Local).AddTicks(6188), true, 432, 70.230000000000004, "11111111-1111-1111-1111-111111111112" },
                    { 4, new DateTime(2024, 4, 2, 10, 6, 58, 462, DateTimeKind.Local).AddTicks(6190), false, 1, 12.43, "11111111-1111-1111-1111-111111111112" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Score",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112");

            migrationBuilder.AlterColumn<decimal>(
                name: "TimeInSeconds",
                table: "Score",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
