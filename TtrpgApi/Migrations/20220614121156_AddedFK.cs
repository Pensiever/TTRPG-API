using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TtrpgApi.Migrations
{
    public partial class AddedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Room",
                table: "Texts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Texts_Room",
                table: "Texts",
                column: "Room");

            migrationBuilder.AddForeignKey(
                name: "FK_Texts_Rooms_Room",
                table: "Texts",
                column: "Room",
                principalTable: "Rooms",
                principalColumn: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Texts_Rooms_Room",
                table: "Texts");

            migrationBuilder.DropIndex(
                name: "IX_Texts_Room",
                table: "Texts");

            migrationBuilder.AlterColumn<string>(
                name: "Room",
                table: "Texts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name1",
                table: "Texts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Texts_Name1",
                table: "Texts",
                column: "Name1");

            migrationBuilder.AddForeignKey(
                name: "FK_Texts_Rooms_Name1",
                table: "Texts",
                column: "Name1",
                principalTable: "Rooms",
                principalColumn: "Name");
        }
    }
}
