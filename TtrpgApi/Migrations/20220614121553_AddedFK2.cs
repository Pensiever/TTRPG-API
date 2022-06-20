using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TtrpgApi.Migrations
{
    public partial class AddedFK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sender",
                table: "Texts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Texts_Sender",
                table: "Texts",
                column: "Sender");

            migrationBuilder.AddForeignKey(
                name: "FK_Texts_Users_Sender",
                table: "Texts",
                column: "Sender",
                principalTable: "Users",
                principalColumn: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Texts_Users_Sender",
                table: "Texts");

            migrationBuilder.DropIndex(
                name: "IX_Texts_Sender",
                table: "Texts");

            migrationBuilder.AlterColumn<string>(
                name: "Sender",
                table: "Texts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
